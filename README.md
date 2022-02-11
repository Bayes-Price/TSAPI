# TSAPI
PoC for REST API implementation of Triple-S

### Testing DemoApp.API
Testing Get /Surveys/{surveyId}/Metadata
user survey id: 1e6cb0a1-2289-4650-9148-9fc3e6e129b2

Testing Post /Surveys/Interviews
sample json to use

```json
{
  "surveyId": "",
  "start": 0,
  "maxLength": 400,
  "completeOnly": false,
  "variables" : ["2","3","15"],
  "interviewIdents": [ "403", "408" ],
  "date": "2020-01-01T03:00:00.000Z"
}
```

json conditions:

1. (Start == null && MaxLength != null || Start != null && MaxLength == null) will return Invalid paging arguments

2. date: is filtered as >=

3. interviewIdents: is filtered as contains

4. the rest uses equals to condition
