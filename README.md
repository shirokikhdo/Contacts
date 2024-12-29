# Contacts

Contacts — это Fullstack приложение для управления контактами, которое позволяет добавлять, редактировать, удалять и просматривать контакты.

## Технологии

### Backend
- [.NET 8.0](https://dotnet.microsoft.com/download/dotnet/8.0) - платформа для разработки
- [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet) - фреймворк для создания веб-приложений
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) - ORM для работы с базами данных
- [SQLite](https://www.sqlite.org/) - cистема управления базами данных

### Frontend
- [React](https://react.dev/) - библиотека для пользовательских интерфейсов
- [Bootstrap](https://getbootstrap.com/) - библиотека для пользовательских интерфейсов

## Библиотеки
### Backend
- Для аутентификации с использованием JWT:
```
dotnet add package Microsoft.Data.Sqlite
```
- Для инструментов разработки Entity Framework Core:
```
dotnet add package Microsoft.EntityFrameworkCore.Tools
```
- Для дизайна Entity Framework Core:
```
dotnet add package Microsoft.EntityFrameworkCore.Design
```
- Для работы с Sqlite через Entity Framework Core:
```
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```
- Для поддержки OpenAPI (Swagger):
```
dotnet add package Microsoft.AspNetCore.OpenApi
```
- Для генерации фейковых данных:
```
dotnet add package Bogus
```
- Для нормальной работы Swagger:
```
dotnet add package Swashbuckle.AspNetCore
```
### Frontend
- Для установки получения стилей пользовательского интерфейса:
```
npm i bootstrap
```
- Для взаимодействия с HTTP запросами:
```
npm i axios
```

## Установка

1. Клонируйте репозиторий:
```git clone https://github.com/shirokikhdo/Contacts.git
cd Contacts
```

2. Восстановите зависимости:

```
dotnet restore
```

3. Создайте базу данных и примените миграции:

```
dotnet ef database update
```
   
4. Запустите приложение:

```
dotnet run
```

## API Endpoints

### ContactManagement
 - **POST /api/ContactManagement/contacts**
	- **Описание:** Добавляет новый контакт в системе.
	- **Тело запроса:** `Contact`
	- **Ответы:**
		- 200 OK: Контакт создан
		- 400 Bad Request: Контакт с таким ID уже существует
- **GET /api/ContactManagement/contacts**
	- **Описание:** Возвращает все контакты в системе.
	- **Ответы:**
		- 200 OK: Существующие контакты
- **GET /api/ContactManagement/contacts/{id}**
	- **Описание:** Получает контакт по идентификатору.
	- **Ответы:**
		- 200 OK: Существующий контакт
        - 400 Bad Request: Ошибка указания ID
        - 404 Not Found: Контакт с таким ID не найден
- **DELETE /api/ContactManagement/contacts/{id}**
	- **Описание:** Удаляет контакт по идентификатору.
	- **Ответы:**
		- 200 OK: Удаляемый контакт
        - 400 Bad Request: Ошибка указания ID
        - 404 Not Found: Контакт с таким ID не найден
- **PUT /api/ContactManagement/contacts/{id}**
	- **Описание:** Обновляет контакт по идентификатору.
    - **Тело запроса:** `ContactDto`
	- **Ответы:**
		- 200 OK: Обновленный контакт
        - 400 Bad Request: Ошибка указания ID
        - 404 Not Found: Контакт с таким ID не найден
- **GET /api/ContactManagement/contacts/page**
	- **Описание:** Возвращает все контакты в системе с учетом пагинации.
    - **Параметры:** `pageNumber`, `pageSize`
	- **Ответы:**
		- 200 OK: Возвращает все контакты в системе с учетом пагинации.