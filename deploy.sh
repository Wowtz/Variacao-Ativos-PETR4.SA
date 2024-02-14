#!/bin/bash

cd VariacaoAtivoWeb

npm install
ng build --configuration production

mv dist/* ../VariacaoAtivoApi/wwwroot

cd ../VariacaoAtivoApi

dotnet publish --configuration Release