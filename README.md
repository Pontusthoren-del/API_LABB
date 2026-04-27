# Avancerad .NET – Labb 3: API med Entity Framework

Ett RESTful API byggt med ASP.NET Core och Entity Framework Core för att hantera användare, intressen och länkar.

## Databasstruktur
- **User** – Information om användaren
- **Interest** – Olika intressen (t.ex. Climbing, Gaming)
- **UserInterest** – Kopplingstabell mellan användare och intressen
- **Link** – Webbadresser kopplade till en användare och ett intresse

---

## Endpoints

### Hämta alla användare
GET /api/Users

**Svar (200 OK):**
```json
[
  { "firstName": "Erik", "lastName": "Larsson", "phoneNumber": "0701111111", "email": "erik@mail.com" }
]
```

---

### Hämta alla intressen för en person
GET /api/Users/{id}/interests

**Svar (200 OK):**
```json
{
  "firstName": "Erik",
  "lastName": "Larsson",
  "interests": [ "Climbing", "Gaming", "Running" ]
}
```
- 404 – Användaren finns inte

---

### Hämta alla länkar för en person
GET /api/Users/{id}/links

**Svar (200 OK):**
```json
{
  "firstName": "Erik",
  "lastName": "Larsson",
  "interestLinks": [
    { "url": "https://climbing.com/", "title": "Climbing" },
    { "url": "https://twitch.tv/", "title": "Gaming" }
  ]
}
```
- 404 – Användaren finns inte

---

### Koppla ett intresse till en person
POST /api/Users/{userId}/Interests

Body: `{ "interestId": 3 }`

- 200 – Intresse kopplat
- 404 – Intresse eller användare finns inte
- 409 – Användaren har redan det intresset (kan ej koppla ett intresse 2 gånger)

---

### Lägga till en länk för en person och ett intresse
POST /api/Users/{id}/interests/{interestId}/links

Body: `{ "url": "https://koket.se", "label": "Köket.se", "interestId": 3 }`

- 200 – Länk tillagd
- 404 – Användaren eller intresset finns inte

---

## Testat med Swagger

Alla endpoints är testade och fungerar!
