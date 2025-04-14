using Python.Runtime;
using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace DocBienSoXe
{
    public partial class Form1 : Form
    {
        string url = "http://127.0.0.1:5000/bien_so_detect";

        private string imgPath;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                imgPath = openFile.FileName;
                picImgOrigin.Image = Image.FromFile(imgPath);
            }
        }

        public Image Base64_to_Img(string base64String)
        {
            try
            {
                byte[] imageBytes = Convert.FromBase64String(base64String);
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    return Image.FromStream(ms);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi chuyển đổi: " + ex.Message);
                return null;
            }
        }
        private async void btnDetection_Click(object sender, EventArgs e)
        {
            if (picImgOrigin.Image != null)
            {
                try
                {
                    var result = await Post(picImgOrigin.Image);

                    // Phân tích JSON
                    JObject json = JObject.Parse(result);
                    Image img = Base64_to_Img(json["image"]?.ToString());
                    String banso = json["license_plate"]?.ToString();
                    if (String.IsNullOrEmpty(banso)) {
                        MessageBox.Show("Lỗi máy chủ không thể đọc","ERROR",MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    picImgCroped.Image = img;
                    txtResult.Text = banso;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hình ảnh trước khi phát hiện!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private async Task<string> Post(Image img)
        {
            using (HttpClient client = new HttpClient()) { 
                 using (var content = new MultipartFormDataContent())
                {
                    // Chuyển đổi Image thành byte[]
                    byte[] imageBytes;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // Lưu ảnh dưới dạng JPEG
                        imageBytes = ms.ToArray();
                    }

                    // Tạo ByteArrayContent từ byte[]
                    var fileContent = new ByteArrayContent(imageBytes);
                    fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");

                    // Thêm file vào nội dung gửi
                    content.Add(fileContent, "file", Path.GetFileName(imgPath));

                    // Gửi POST request
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    string result = await response.Content.ReadAsStringAsync();

                    return result; // Trả về kết quả từ API
                }    
            }  
        }
    }
}