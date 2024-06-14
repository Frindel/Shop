## Описание
Проект - сервис для предоставления информации о списке товаров, а также возможностью заказа/удаления товара и заказа.
Для организации структуры проекта использовалась луковая архитектура. С целью, обеспечения единообразного интерфейса обработки запросов, использовлись MediatoR и SQRC.

## Методы
### GET /api/accounts/register?isAdmin=[true/false]
Выполняет регистрацию нового пользователя. Результатом работы являются access и refresh токены.

**Ответ**:
```
{
  "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6...",
  "refreshToken": "IW12itqdfLTx253ewOqYFhYByAo..."
}
```
### POST /api/accounts/update-token
Выполняет переиздание access и refresh токенов. Используется при истечении срока жизни access-токена.

**Запрос**:
```
{
  "refreshToken": "IW12itqdfLTx253ewOqYFhYByAo..."
}
```
**Ответ**:
```
{
  "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6...",
  "refreshToken": "IW12itqdfLTx253ewOqYFhYByAo..."
}
```

### GET /api/products
Возвращает список всех продуктов.

**Ответ**:
```
{
  "products": [
    {
      "id": 1,
      "name": "Продукт 1",
      "price": 100
    },
    {
      "id": 2,
      "name": "Продукт 2",
      "price": 200
    },
    {
      "id": 3,
      "name": "Продукт 3",
      "price": 300
    }
    ...
  ]
}
```
### POST /api/products
Добавляет новый продукт. Возвращает добавленный продукт с присвоенным ему id.

**Запрос**:
```
{
  "name": "product 1",
  "price": 3000
}
```

**Ответ**:
```
{
  "id": 2,
  "name": "product 1",
  "price": 3000
}
```

### DELETE /api/products
Удаляет продукта по id.

**Запрос**:
```
{
  "id": 2
}
```

**Ответ**:
Отсутствует тело ответа.

### GET /api/orders
Возвращает список всех заказов пользователя.

**Ответ**:
```
{
  "orders": [
    {
      "id": 1,
      "product": [
        {
          "id": 1,
          "name": "Продукт 1",
          "price": 0
        },
        {
          "id": 2,
          "name": "Продукт 2",
          "price": 0
        },
        {
          "id": 3,
          "name": "Продукт 3",
          "price": 0
        }
      ]
    }
    ...
  ]
}
```

### POST /api/orders
Добавляет новый заказ.

**Запрос**:
```
{
  "productsId": [1, 2]
}
```

**Ответ**:
```
{
  "id": 1,
  "productsId": [1, 2]
}
```

### PUT /api/orders
Редактирует заказ по id. Возвращает измененный заказ.

**Запрос**:
```
{
  "id": 1,
  "productsId": [1]
}
```

**Ответ**:
```
{
  "id": 1,
  "productsId": [1]
}
```

### DELETE api/orders
Удаляет заказ по id.

**Запрос**:
```
{
  "id": 1
}
```

**Ответ**:
Отсутствует тело запроса.

## Пример работы
В проекте присутствуют тестовые данные: товары, заказ и пользователь с правами админа.
Для получения access-токена существующего пользователя, требуется выполнить запрос:
```
POST /api/accounts/update-token
{
    "refreshToken": "xdb04oV0gHEgmGMvWXs7I4k4dMKZTwlZjNJoyUH7af4FA+dQsomacLIQcDGpJyuhNm6XqewoChBgpI2R2e9v0Q=="
}
```
Полученный access-токен необходимо установить в заголовок т.к. методы работы с товарами и заказами требуют его наличия:
```
Authorization: Bearer [access-token]
```
