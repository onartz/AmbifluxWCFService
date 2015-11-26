Générer la solution puis recopier le fichier /bin/AmbifluxWcfService.dll sous aip-sqlaipl\disque_c\temp\JSON\bin

Pour tester le service :
http://aip-sqlaipl/AmbifluxWcfService/ambiflux.svc/json/employeeByCardId/64734E23
http://aip-sqlaipl/AmbifluxWcfService/ambiflux.svc/json/productInventory/1/1
http://aip-sqlaipl/AmbifluxWcfService/ambiflux.svc/json/productLevel/1/1
http://aip-sqlaipl/AmbifluxWcfService/ambiflux.svc/json/productLevel/1



Pour le service en production, repoier le fichier sous aip-sqlaipl\disque_c\inetpub\www\WcfService\bin
Pour tester le service :
http://aip-sqlaipl:4567/ambiflux.svc/json/employeeByCardId/64734E23
http://aip-sqlaipl:4567/ambiflux.svc/json/productLevel/1
http://aip-sqlaipl:4567/ambiflux.svc/json/productInventory/1/1
