# TSAPI
PoC for REST API implementation of Triple-S

###Testing DemoApp.API
Testing Post /Surveys/Interviews
sample json

{
  "surveyId": "",
  "start": 0,
  "maxLength": 400,
  "completeOnly": false,
  "variables" : ["2","3","15"],
  "interviewIdents": [ "403", "408" ],
  "date": "2020-01-01T03:00:00.000Z"
}

json conditions:

1. (Start == null && MaxLength != null || Start != null && MaxLength == null) 
    return Invalid paging arguments

2. date: is filtered as >=

3. interviewIdents: is filtered as contains

4. the rest uses equals to condition