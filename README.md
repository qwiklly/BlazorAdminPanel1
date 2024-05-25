# Описание: AdminPanel (Панель администратора)
Этот проект представляет собой панель администратора. Он обладает следующими функциями: добавление пользователя и его роли, удаление пользователя, авторизация. Операции осуществляются с помощью Web токенов JWT, а данные передаются через API. Кроме того, каждый пользователь имеет роль, и некоторый функционал проекта зависит от роли пользователя.

# Используемые технологии
* NET Core 8.0
* Azure.Identity
* BCrypt.Net-Next
* Microsoft.Data.SqlClient
* Microsoft.EntityFrameworkCore
* Microsoft.EntityFrameworkCore.SqlServer
* Swashbuckle.AspNetCore
* System.IdentityModel.Tokens.Jwt
* Microsoft.AspNetCore.Authentication.JwtBearer
* Microsoft.AspNetCore.Components.Authorization

# Основной функционал:
* Добавление пользователя.
* Удаление пользователя.
* Авторизация.
* Назначение ролей.

# При запуске:
Возможно при запуске потребуется обновить базу данных, для этого в консоле диспетчера пакетов пропишите данную команду

![image](https://github.com/qwiklly/BlazorAdminPanel1/assets/157243767/7a57b1e9-3b7b-4610-9ad1-2f550c4e15f2)
  
## Изображения форм
### **Начальный экран**

![Screenshot 2024-05-19 201348](https://github.com/qwiklly/BlazorAdminPanel1/assets/157243767/5ce6d94b-36d3-45a5-bf44-e128f36557ed)

### **Окно входа**

![Screenshot 2024-05-19 201357](https://github.com/qwiklly/BlazorAdminPanel1/assets/157243767/e3ecb6cb-5715-4f83-b264-709afed34919)

### **Окно добавления пользователя**

![Screenshot 2024-05-19 201425](https://github.com/qwiklly/BlazorAdminPanel1/assets/157243767/ee0b4c3a-07bd-47c9-9a92-b9b2754f6966)

### **Список пользователей и удаление**

![Screenshot 2024-05-19 201436](https://github.com/qwiklly/BlazorAdminPanel1/assets/157243767/55095b65-803c-4544-8e2c-ad8a3006fe88)

### **Список пзапросов транспортных средств с их координатами и удаление**

![image](https://github.com/qwiklly/BlazorAdminPanel1/assets/157243767/8565abf1-5f7f-47f8-8ccd-892a8527e501)

### **Окно Swagger**

![Screenshot 2024-05-19 201509](https://github.com/qwiklly/BlazorAdminPanel1/assets/157243767/0e3b57c0-ad27-4800-b27c-71db1a1fb82e)

## Видеообзор проекта

https://github.com/qwiklly/BlazorAdminPanel1/assets/157243767/342e70c3-cc14-43d0-93a6-5f2c32a6673d
