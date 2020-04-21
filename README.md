# Gestion des Présences

Gestion des présences des séances d'une école et simulation de pointage des étudiants par leurs cartes RFID
 
# En cas d'utilisation du script de la base données:

Créer une nouvelle base de donnée nommé **projet_gestionpresencedb** sur MySQL. 
sélectionner la base de donné projet_gestionpresencedb puis Importer le fichier **projet_gestionpresencedb.sql**

ouvrez le terminal et tapez la commande suivante :

 -----> dotnet watch run
 
Compte Admin:
Nom d'utilisateur (Email) : admin@admin.com
Mot de Passe : Admin$123

Compte Professeur
Nom d'utilisateur (Email) : y@y.y
Mot de Passe : Yy$123

 
Pour les autres comptes, les mot de passe commence par la première lettre de l'email
Exemple: Email : c@c.c
Mot de passe : Cc$123

# Si vous n'utiliser pas le script .sql
ouvrez terminal et tapez les commandes suivantes :

 -----> cd GestionPresence
 
-----> dotnet ef migrations add CreateDb
 
 ----->dotnet ef database update 
 
Une page s'ouvrira pour l'ajout d'un compte Administrateur et l'ajout d'une année universitaire est obligatoire.


