# API Labb

## Endpoints

### Hämta alla personer
GET /api/Persons

### Hämta alla intressen för en person
GET /api/Persons/{id}/interests

### Hämta alla länkar för en person
GET /api/Persons/{id}/links

### Koppla ett intresse till en person
POST /api/Persons/{id}/interests

Body:
{
  "interestId": 3
}

### Lägga till en länk för en person och ett intresse
POST /api/Persons/{id}/interests/{interestId}/links

Body:
{
  "url": "https://koket.se",
  "label": "Köket.se",
  "interestId": 3
}

## Testat med Swagger
Alla endpoints är testade och fungerar!
