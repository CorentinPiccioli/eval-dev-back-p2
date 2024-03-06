# Documentation de l'API des événements

## Endpoints

### Ajouter un événement

- **URL** : `/event/add`
- **Méthode** : `POST`
- **Données d'entrée** : Un objet JSON représentant l'événement à ajouter.

Exemple de données d'entrée :

```json
{
    "Title": "Mon événement",
    "Description": "C'est mon événement",
    "Date": "2023-12-31T23:59:59",
    "Location": "Mon lieu"
}
```

### Supprimer un événement

- **URL** : `/event/delete/{id}`
- **Méthode** : `DELETE`
- **Paramètres d'URL** : `id` - L'identifiant de l'événement à supprimer.

### Lister les événements

- **URL** : `/event/list`
- **Méthode** : `GET`

### Mettre à jour un événement

- **URL** : `/event/update`
- **Méthode** : `PUT`
- **Données d'entrée** : Un objet JSON représentant l'événement à mettre à jour.

Exemple de données d'entrée :

```json
{
    "Id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "Title": "Mon événement mis à jour",
    "Description": "C'est mon événement mis à jour",
    "Date": "2023-12-31T23:59:59",
    "Location": "Mon lieu mis à jour"
}
```

## Modèles

### Event

Représente un événement.

- **Id** : L'identifiant de l'événement.
- **Title** : Le titre de l'événement.
- **Description** : La description de l'événement.
- **Date** : La date de l'événement.
- **Location** : Le lieu de l'événement.

## Codes de réponse

- `200` : L'opération a réussi.
- `500` : Une erreur est survenue lors de l'exécution de l'opération.