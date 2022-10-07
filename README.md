# Anti-Curroption-Layer-simple-implementation
This repository contains a sample implementation for Anti Curroption Layer design pattern.<br/>

befor starting let's define a business use case for using ACL. <br/>

## Business Use Case :
let's say we have an e-commerce and we are working on Order module, for order context we need to deal with product context which provided by 3rd party system.<br/>
Here it comes the value of ACL in order to depend on 3rd party context , ACL decouple the dependency from our domain. <br/>

## Building Blocks for ACL :

![alt text](https://github.com/mfaddo/Anti-Curroption-Layer-simple-implementation/blob/master/ACL-%20Diagram%20(1).png)
as long as our domain should not depend on infrastructure to communicate with product context we need to create a translator layer that decouple the dependency. 
<li>The traslator is the contract wich map product context model to order context.</li>
<li>Adaptor is the main componenet that communicate with 3rd party.It is the implementation for the communcation (Data Access , Http , API).</li>

## Implementation:
For our example let's say product context can be accessed using old fashion SQL Views.Then we need to create:

- `IProductTranslator` which contains the contract in our domain.
- Create `ProductDatabaseTranlator` which impelement the above interface and map returned product from SQL to our domain entity.
- `ItemsDataBaseAdapter` which efcore implementation to access the SQL view that provieded from our 3rd party.
![alt_text](https://github.com/mfaddo/Anti-Curroption-Layer-simple-implementation/blob/master/ACL-Db-Adapter.png)
## Why we did this?
let's take this to another level, what if our 3rd party providers upgraded their software and they provides us an API to communicate with product context.<br/>
In this case the only change would be to change the translator and adaptor without touching the domain. 
- We need to re-impelement the interface by creating `ProductAPITranslator`.
- write new adaptor to access the API `ItemsApiAdaptor`. 
![alt_text](https://github.com/mfaddo/Anti-Curroption-Layer-simple-implementation/blob/master/ACL-API-Adapter-1.png)
Note that both translators is provided in the repository to simulate how easy and clean the changing was.

### Note all to-gother , we did not change any thing in domain even the 3rd party changed the schema. 
![alt_text](https://github.com/mfaddo/Anti-Curroption-Layer-simple-implementation/blob/master/ACL-AllTogether.png)
