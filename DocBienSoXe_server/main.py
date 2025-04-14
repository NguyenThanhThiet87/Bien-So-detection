import cv2
from ultralytics import YOLO
import easyocr
import numpy as np
from fastapi import FastAPI, UploadFile, File, HTTPException
from fastapi.responses import JSONResponse
import base64
import pathlib as Path
# Khởi tạo FastAPI
app = FastAPI()

# Load mô hình YOLO
model = YOLO("D:\\PhatHienBanSoXeMay\\DocBienSoXe_server\\license_plate_detection.pt")

def encode_image_to_base64(image):
    _, buffer = cv2.imencode(".jpg", image)  # Chuyển ảnh thành buffer
    return base64.b64encode(buffer).decode("utf-8")  # Chuyển buffer thành chuỗi base64

# Khởi tạo EasyOCR (hỗ trợ tiếng Anh và tiếng Việt)
reader = easyocr.Reader(["en", "vi"])
@app.get("/")
async def root():
    return {"message": "Welcome to License Plate Detection API"}

@app.post("/bien_so_detect")
async def detect_license_plate(file: UploadFile = File(...)):
    try:
        # Đọc dữ liệu ảnh từ file upload
        contents = await file.read()
        if not contents:
            raise HTTPException(status_code=400, detail="File ảnh rỗng.")

        # Chuyển dữ liệu bytes thành ảnh bằng OpenCV
        nparr = np.frombuffer(contents, np.uint8)
        image = cv2.imdecode(nparr, cv2.IMREAD_COLOR)

        # Kiểm tra xem ảnh có được đọc thành công không
        if image is None:
            raise HTTPException(status_code=400, detail="Không thể đọc hình ảnh.")

        # Phát hiện biển số xe bằng YOLOv8
        results = model(image)

        # Đọc biển số
        bienso = ""
        cropped_img = []
        if len(results[0].boxes.xyxy) > 0:  # Kiểm tra xem có bounding box không
            for box in results[0].boxes.xyxy:
                x1, y1, x2, y2 = map(int, box.tolist())  # Chuyển tọa độ về số nguyên
                # Cắt vùng ảnh theo bounding box
                cropped_img = image[y1:y2, x1:x2]
                # Kiểm tra ảnh cắt có hợp lệ không
                if cropped_img.shape[0] > 0 and cropped_img.shape[1] > 0:
                    result_text = reader.readtext(cropped_img)
                    for detection in result_text:
                        bienso += detection[1] + " "
                else:
                    continue  # Bỏ qua nếu ảnh cắt không hợp lệ

        # Trả về kết quả JSON
        return JSONResponse({"image":encode_image_to_base64(cropped_img),"license_plate": bienso.strip()})

    except Exception as e:
        raise HTTPException(status_code=500, detail=f"Lỗi: {str(e)}")

# Chạy server
if __name__ == "__main__":
    import uvicorn
    uvicorn.run(app, host="127.0.0.1", port=5000)