# Stage 1: Build
# ใช้ภาพพื้นฐาน (Base Image) ของ .NET SDK 7.0 ซึ่งรวมเครื่องมือสำหรับการพัฒนา เช่น `dotnet build`, `dotnet publish` ฯลฯ
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# ตั้งค่าโฟลเดอร์ทำงานภายใน Container เป็น `/app`
WORKDIR /app

# คัดลอกไฟล์ทั้งหมดจากโฟลเดอร์ปัจจุบันของโปรเจกต์ (บนเครื่องเรา) ไปยังโฟลเดอร์ `/app` ใน Container
COPY . .

# เรียกใช้คำสั่ง `dotnet restore` เพื่อดึง Dependencies ที่จำเป็นสำหรับโปรเจกต์มาจาก NuGet
# Dependencies จะถูกเก็บไว้ใน Cache ของ Container
RUN dotnet restore

# เรียกใช้คำสั่ง `dotnet publish` เพื่อสร้างไฟล์โปรเจกต์ที่พร้อมสำหรับการรันใน Production
# การตั้งค่า `-c Release` จะสร้าง Build แบบ Release
# ผลลัพธ์จะถูกบันทึกไว้ในโฟลเดอร์ `/publish` ภายใน Container
RUN dotnet publish -c Release -o /publish

# Stage 2: Run
# ใช้ภาพพื้นฐาน (Base Image) ของ ASP.NET Runtime 7.0 ซึ่งมีเฉพาะ Runtime ของ .NET และเหมาะสำหรับการรันแอปพลิเคชันใน Production
FROM mcr.microsoft.com/dotnet/aspnet:7.0

# ตั้งค่าโฟลเดอร์ทำงานใน Container สำหรับการรันแอปพลิเคชันเป็น `/app`
WORKDIR /app

# คัดลอกไฟล์ที่ถูก Build ใน Stage 1 (`/publish`) ไปยังโฟลเดอร์ `/app` ใน Container
COPY --from=build /publish .

# กำหนดคำสั่งเริ่มต้น (Entry Point) ของ Container เมื่อรันขึ้น
# จะรันคำสั่ง `dotnet YourProject.dll` เพื่อเปิดแอปพลิเคชัน
ENTRYPOINT ["dotnet", "YourProject.dll"]
