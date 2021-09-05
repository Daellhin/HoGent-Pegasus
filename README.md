# Pegasus Training Web App
[![Publish](https://github.com/Web-IV/2021-benjamin-LorinSpeybrouck/actions/workflows/publish.yml/badge.svg?branch=main)](https://github.com/Web-IV/2021-benjamin-LorinSpeybrouck/actions/workflows/publish.yml)
[![Test](https://github.com/Web-IV/2021-benjamin-LorinSpeybrouck/actions/workflows/test.yml/badge.svg?branch=dev)](https://github.com/Web-IV/2021-benjamin-LorinSpeybrouck/actions/workflows/test.yml)

This repo contains:
- A .Net Web API in the [./pegasus](./pegasus) directory
- A Angular front end in the [./pegasus/client](./pegasus/client) directory

## Live application
Hosted at: https://www.pega.lorinspeybrouck.be

## Aditional Features
- continuous integration with github actions
- ngx-charts for showing charts of registrations
- ngx-markdown for converting the changelog.md file to html and showing it in the web application

## Install and run
Clone the repository
```
git clone https://github.com/Web-IV/2021-benjamin-LorinSpeybrouck.git
```
Run the API, this will also install node-modules and start the Angular app 
```
dotnet run
```
Open browser at http://localhost:4200

## Changelog
[Link to changelog](./pegasus/client/src/assets/changelog.md)
