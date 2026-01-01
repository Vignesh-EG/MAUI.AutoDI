# 🚀 MAUI.AutoDI
**Convention-based Automatic Dependency Injection for .NET MAUI**

MAUI.AutoDI removes repetitive dependency registrations in .NET MAUI projects by automatically registering Pages, ViewModels, and Services using **naming conventions** and **attributes**.

---

## ✨ Features

- ✅ Zero manual `AddSingleton / AddTransient`
- ✅ Convention-based registration
- ✅ Default **Singleton** lifetime
- ✅ Attribute-based lifetime override
- ✅ Ability to ignore specific classes
- ✅ Interface-to-implementation auto mapping
- ✅ Works on Windows, Android, and iOS
- ✅ Reusable across multiple MAUI projects
- ✅ NuGet-ready architecture

---

## 📦 Installation

### Option 1: Project Reference
1. Create a **Class Library (.NET)** project  
2. Target **.NET 7 or .NET 8**
3. Reference it from your MAUI project



### Option 2: NuGet
> Planned for future release

---

## 🧱 Naming Conventions

| Type | Naming Rule | Auto Registered |
|----|----|----|
| Pages | `*Page` | ✅ |
| ViewModels | `*ViewModel` | ✅ |
| Services | `*Service` | ✅ |
| Others | Any | ❌ |

---

## 🔄 Default Lifetime Rules

| Component | Lifetime |
|--------|---------|
| Page | Singleton |
| ViewModel | Singleton |
| Service | Singleton |

> Lifetimes can be overridden using attributes.

---

## 🧠 How It Works

1. Scans the provided assembly
2. Finds eligible classes by naming convention
3. Skips ignored classes
4. Determines lifetime via attribute or default
5. Registers services automatically

---

## 🚀 Usage

### Register Services Automatically

In `MauiProgram.cs`:

```csharp
using MAUI.AutoDI.Extensions;
using System.Reflection;

builder.Services.AutoRegisterFromAssembly(
    Assembly.GetExecutingAssembly());



# Available Lifetimes
ServiceLifetimeType.Singleton
ServiceLifetimeType.Transient
ServiceLifetimeType.Scoped


Example: Transient ViewModel
using MAUI.AutoDI.Attributes;
using MAUI.AutoDI.Enums;

[ServiceLifetime(ServiceLifetimeType.Transient)]
public class FlyoutTemplateViewModel
{
}


Ignore Auto Registration

To prevent a class from being registered:

using MAUI.AutoDI.Attributes;

[IgnoreAutoRegister]
public class MathHelper
{
}
