# First Assignment – Tech Lead Application (School Bright)

## 🎯 วัตถุประสงค์
Assignment นี้เป็นส่วนหนึ่งของการสมัครเข้ารับตำแหน่ง **Tech Lead** ที่บริษัท **School Bright**  
เพื่อทดสอบความสามารถในการพัฒนา **RESTful API** ด้วย **.NET Core 9** และการออกแบบโครงสร้างโปรเจกต์ที่สะอาด (Clean Architecture)

---

## 📂 โครงสร้างงาน

- **Controllers/** → API Endpoint ต่าง ๆ  
- **Data/** → Context และการเชื่อมต่อฐานข้อมูล  
- **Dtos/** → Data Transfer Objects (รับ–ส่งข้อมูล)  
- **Helpers/** → ฟังก์ชันอำนวยความสะดวก  
- **Mappers/** → Mapping ระหว่าง Entity ↔ DTO  
- **Migrations/** → การสร้างและปรับโครงสร้างฐานข้อมูล  
- **Models/** → Entity หลัก  
- **Validator/** → ตรวจสอบข้อมูลด้วย Fluent Validation  
- **Dockerfile** → Containerization สำหรับ Deploy  
- **api.http** → ตัวอย่างการทดสอบ API  

---

## ⚙️ เทคโนโลยีที่ใช้
- **.NET Core 9.0**  
- **Entity Framework Core** (ORM & Migration)  
- **Fluent Validation** (Input validation)  
- **Docker** (Deploy ข้าม environment)  
- **RESTful API Standards**  

---

## 🚀 สิ่งที่ Assignment พิสูจน์ได้
1. **ความสามารถในการออกแบบ API ที่เป็นระบบ**  
   - แยก Layer ชัดเจน: Controller, Service, DTO, Validator  

2. **Clean Code + Best Practice**  
   - ใช้ DTO + Validator ลด bug และเพิ่มความยืดหยุ่น  
   - โครงสร้าง project รองรับการ maintain และ scale  

3. **Production Ready**  
   - รองรับ Database Migration  
   - รองรับ Containerization (Dockerfile)  
   - มีไฟล์ `.http` สำหรับทดสอบ API  

---

## 📌 สรุป
งาน **First Assignment** นี้สะท้อนว่า:  
- สามารถสร้าง API ได้ด้วย **.NET Core 9**  
- มีทักษะออกแบบ **ระบบที่ขยายต่อได้**  
- เข้าใจ **Best Practices** และการทำงานเชิง Production  

---
