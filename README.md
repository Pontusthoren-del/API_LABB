# API Labb

## Endpoints

### Hämta alla personer
GET /api/Users

### Hämta alla intressen för en person
GET /api/Users/{id}/interests

### Hämta alla länkar för en person
GET /api/Users/{id}/links

### Koppla ett intresse till en person
POST /api/Users/{id}/interests

Body:
{
  "interestId": 3
}

### Lägga till en länk för en person och ett intresse
POST /api/Users/{id}/interests/{interestId}/links

Body:
{
  "url": "https://koket.se",
  "label": "Köket.se",
  "interestId": 3
}

## Testat med Swagger
Alla endpoints är testade och fungerar!
