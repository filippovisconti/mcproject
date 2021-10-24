using System;
using Amazon;
using Amazon.CognitoIdentity;
using Amazon.RDS;

namespace mcproject.Services
{
    public class CognitoService
    {
        CognitoAWSCredentials credentials;

        public CognitoService()
        {
            // Initialize the Amazon Cognito credentials provider
            credentials = new CognitoAWSCredentials(
                Constants.poolID, // Your identity pool ID
                RegionEndpoint.USEast2 // Region
                );
        }

        public void testConnection(CognitoAWSCredentials cred)
        {
            var client = new AmazonRDSClient(cred, );
        }
    }
}
