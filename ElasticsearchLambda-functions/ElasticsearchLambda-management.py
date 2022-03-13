import boto3
import json
import requests
from requests_aws4auth import AWS4Auth

region = 'us-east-1'
service = 'es'
credentials = boto3.Session().get_credentials()
awsauth = AWS4Auth(credentials.access_key, credentials.secret_key, region, service, session_token=credentials.token)

host = 'https://search-management-9cv7frvthfe5654hy2ykppgaeu.us-east-1.es.amazonaws.com/' # The elastic search domain endpoint //
index = 'management'
url = host + '/' + index + '/_search'

#  lambda function execution
def lambda_function.lambda_handler(event, context)

    # Some fields are boosted (^).
    query = {
        "size": 25,
        "query": {
            "multi_match": {
                "query": event['queryStringParameters']['q'],
                "fields": ["name", "market^4", "state"]
            }
        }
    }

    headers = { "Content-Type": "application/json" }

    # The response and some extra content to support CORS
    response = {
        "statusCode": 200,
        "headers": {
            "Access-Control-Allow-Origin": '*'
        },
        "isBase64Encoded": False
    }

    #  Search results to the response
    response['body'] = r.text
    return response