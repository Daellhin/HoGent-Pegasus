# Changelog

Changelog of the Pegasus Training Web App
<br/><br/>

## [1.1] - Improvements

Improvements:
- Separate router module
- Lazy loaded changelog module
- Error handling on registration POST
- Cypres testing for pages: /inschrijven, /trainers, /changelog
- Added DTO's to API methods for better domain separation
 
New Features:
- Loading bars
  > Loading bars for registration, trainer, changelog page
- Account registration and login
  > A logged in user can register new accounts

## [1.0] - Initial Release

New features:

- Registration page
  > Contains a form where the user can select 1 or more training and a name field
- Confirmation page
  > Is displayed after a succesfull registration
- Overview page for trainers of registrations
  > Contains a section per training with information about that training and the registrations
- Error page
  > For displaying generic or HTTP errors
- Changelog page
  > A page for displaying this markdown file
