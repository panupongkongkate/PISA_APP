# PISA Exam System 📚

ระบบข้อสอบออนไลน์ PISA (Program for International Student Assessment) เป็นระบบจัดการและทำข้อสอบออนไลน์ที่พัฒนาด้วย Blazor Server

## 🌟 คุณสมบัติหลัก

### 👥 ระบบผู้ใช้งาน
- **Admin**: จัดการผู้ใช้ทั้งหมด, ดูรายงาน, จัดการระบบ
- **Teacher**: จัดการวิชาที่สอน, สร้างข้อสอบ, ดูผลการสอบ
- **Student**: เข้าสอบ, ดูผลการสอบ, จัดการโปรไฟล์

### 📊 ฟีเจอร์เด่น
- ✅ **การจัดการผู้ใช้** - CRUD operations พร้อม pagination และ search
- ✅ **ระบบข้อสอบ** - สร้าง, แก้ไข, และจัดการข้อสอบ
- ✅ **การทำข้อสอบ** - ระบบทำข้อสอบแบบ real-time พร้อม timer
- ✅ **รายงานและสถิติ** - Dashboard, charts, และ export ข้อมูล
- ✅ **เอกสารประกอบ** - Database schema, API design, Project structure
- ✅ **Responsive Design** - รองรับทุกอุปกรณ์

## 🛠️ เทคโนโลยีที่ใช้

### Backend
- **ASP.NET Core 8.0** - Web framework
- **Blazor Server** - Server-side rendering with SignalR
- **C# 12** - Programming language

### Frontend
- **Bootstrap 5.3.2** - CSS framework
- **FontAwesome 6.4.0** - Icons
- **JavaScript** - Client-side interactions

### Libraries & Tools
- **Microsoft.JSInterop** - JavaScript interoperability
- **System.ComponentModel.DataAnnotations** - Data validation

## 🚀 การติดตั้งและรันโปรแกรม

### ข้อกำหนดระบบ
- **.NET 8.0 SDK** หรือใหม่กว่า
- **Visual Studio 2022** (แนะนำ) หรือ **Visual Studio Code**
- **Web Browser** (Chrome, Firefox, Edge, Safari)

### ขั้นตอนการติดตั้ง

1. **Clone หรือ Download โปรเจค**
   ```bash
   git clone <repository-url>
   cd PISA_APP
   ```

2. **ตรวจสอบ .NET SDK**
   ```bash
   dotnet --version
   # ควรแสดง 8.0.x หรือใหม่กว่า
   ```

3. **Restore Dependencies**
   ```bash
   dotnet restore
   ```

4. **Build โปรเจค**
   ```bash
   dotnet build
   ```

5. **รันโปรแกรม**
   ```bash
   dotnet run
   ```

6. **เปิดเว็บไซต์**
   - เปิดเบราว์เซอร์และไปที่ `https://localhost:7175` หรือ `http://localhost:5044`

### การติดตั้งแบบ Production

```bash
# Build สำหรับ production
dotnet publish -c Release -o ./publish

# รันจาก published files
cd publish
dotnet PISA_APP.dll
```

## 👤 การเข้าสู่ระบบ

### บัญชีเริ่มต้น (Mock Data)

#### Admin Account
- **Username**: `admin01`
- **Password**: `admin123`

#### Teacher Account  
- **Username**: `teacher001`
- **Password**: `teacher123`

#### Student Account
- **Username**: `student001`
- **Password**: `student123`

## 📁 โครงสร้างโปรเจค

```
PISA_APP/
├── Components/
│   ├── Layout/                 # Layout components
│   ├── Pages/                  # Page components
│   │   ├── Auth/              # Authentication pages
│   │   ├── UserManagement/    # User management
│   │   ├── ContentManagement/ # Content management
│   │   └── Student/           # Student features
│   └── Shared/                # Shared components
├── Models/                    # Data models
├── Services/                  # Business logic
├── wwwroot/                   # Static files
└── Program.cs                 # Application entry point
```

## 🗄️ ฐานข้อมูล

โปรเจคนี้ใช้ **Mock Data Service** แทนฐานข้อมูลจริง ข้อมูลจะถูกสร้างขึ้นอัตโนมัติเมื่อเริ่มแอปพลิเคชัน:

- **150+ Users** (5 Admins, 25 Teachers, 120 Students)
- **50 Subjects** หลากหลายสาขา
- **200 Exams** ประเภทต่างๆ
- **500+ Exam Results** สำหรับการทดสอบ

## 🎯 การพัฒนาต่อ

### สำหรับการใช้งานจริง ควรเพิ่ม:
1. **ฐานข้อมูลจริง** (SQL Server, PostgreSQL, MySQL)
2. **Authentication Provider** (Identity Server, Azure AD)
3. **File Storage** สำหรับอัปโหลดไฟล์
4. **Email Service** สำหรับส่งอีเมล
5. **Logging** และ **Monitoring**
6. **Unit Tests** และ **Integration Tests**

### การเพิ่ม Dependencies

```bash
# Entity Framework Core (สำหรับฐานข้อมูลจริง)
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools

# Identity (สำหรับ Authentication)
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore

# SignalR (อาจต้องการสำหรับ real-time features)
dotnet add package Microsoft.AspNetCore.SignalR
```

## 🐛 การแก้ไขปัญหา

### ปัญหาที่พบบ่อย

1. **Port ถูกใช้งานแล้ว**
   ```bash
   # เปลี่ยน port ใน Properties/launchSettings.json
   ```

2. **JavaScript errors**
   ```bash
   # ตรวจสอบ console ของเบราว์เซอร์
   # รีเฟรช hard reload (Ctrl+F5)
   ```

3. **Build errors**
   ```bash
   dotnet clean
   dotnet restore
   dotnet build
   ```

## 📝 License

This project is for educational purposes only.

## 🤝 การสนับสนุน

หากพบปัญหาหรือต้องการข้อมูลเพิ่มเติม กรุณาสร้าง Issue ใน repository นี้

---

**สร้างโดย**: Claude AI Assistant  
**วันที่**: December 2024  
**เวอร์ชัน**: 1.0.0