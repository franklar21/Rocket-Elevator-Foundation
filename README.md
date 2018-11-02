# API_CSharp
 Voici des exemples de requêtes pouvant être appliquées à l’API REST

Récupération du Statut actuel d’une Batterie d’ascenseurs pour une Batterie spécifiée:
GET https://rocketcsharpapi.azurewebsites.net/api/batteries/(#batterie)  
 Modification du Statut d’une Batterie d’ascenseurs spécifiée:
PUT https://rocketcsharpapi.azurewebsites.net/api/batteries/(#batterie)  
	JSON:
	{
		"status": "(Statut)"
	}
	
Récupération du Statut actuel d’une Colonne d’ascenseurs pour une Batterie  spécifiée :
GET https://rocketcsharpapi.azurewebsites.net/api/columns/(#colonne) 
 Modification du Statut d’une Colonne d’ascenseurs spécifiée:
PUT https://rocketcsharpapi.azurewebsites.net/api/columns/(#colonne) 
	JSON:
	{
		"status": "(Statut)"
	}
	
 Récupération du Statut actuel d’une Cage d’ascenseur pour une cage spécifiée:
GET https://rocketcsharpapi.azurewebsites.net/api/elevators/(#ascenseur) 
 Modification du Statut d’une Cage d’ascenseur spécifiée:
PUT https://rocketcsharpapi.azurewebsites.net/api/elevators/(#ascenseur) 
	JSON:
	{
		"status": "(Statut)"
	}
	
 Récupération d’une liste d’ascenseurs qui ne sont pas en opération au moment de  la requête:
 GET https://rocketcsharpapi.azurewebsites.net/api/elevators/status

Récupération d’une liste de buildings qui contiennent au moins une batterie, une  colonne ou un ascenseur requérant une intervention 
 GET https://rocketcsharpapi.azurewebsites.net/api/buildings/status

Récupération d’une liste de leads créés au cours des 30 derniers jours qui ne sont  pas encore devenus des clients
GET https://rocketcsharpapi.azurewebsites.net/api/leads/latest


