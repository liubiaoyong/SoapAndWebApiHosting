A sample app to show Hosting of SOAP and REST api in the same ASPNET Web API project

1. Clone the run the application
2. For Json REST API    
    Request: GET http://localhost:16977/value
    
    Resposne: [
                  "value1",
                  "value2"
              ]

3. For SOAP API
    
**Request**:
            POST http://localhost:16977/soap/ValuesService.svc 
            
            SOAPAction: http://tempuri.org/IValuesService/GetAll  
            Content-Type: text/xml
```xml
            <Envelope xmlns="http://schemas.xmlsoap.org/soap/envelope/">
                <Body>
                    <GetAll xmlns="http://tempuri.org/"/>
                </Body>
            </Envelope>
```
**Response**:
```xml
    <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">
    <s:Body>
        <GetAllResponse xmlns="http://tempuri.org/">
            <GetAllResult xmlns:a="http://schemas.microsoft.com/2003/10/Serialization/Arrays" xmlns:i="http://www.w3.org/2001/XMLSchema-instance">
                <a:string>value1</a:string>
                <a:string>value2</a:string>
            </GetAllResult>
        </GetAllResponse>
    </s:Body>
    </s:Envelope>
```
                        
    
