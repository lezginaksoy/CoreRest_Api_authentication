# CoreRest_Api_authentication

Asp.NET Core 2.0 WebApi JWT Authentication with Identity & postgresql


-Bearer Token Authentication 

What’s in a JWT?

It’s useful to understand the basic structure of a JSON Web Token.

It consists of three parts, separated by a .

HEADER.PAYLOAD.SIGNATURE

The header indicates that the token is JWT and which hashing algorithm has been used when creating it. This is Base64Url encoded.

The payload is the part that is the application-specific part which holds claims you wish to transmit (also Base64Url encoded).


using the algorithm specified in the header, your server will concatenate the encoded header and payload, then sign them using a secret.

That signature is then appended to the end of the token and can be used (by anyone who has the secret)
 to verify that the sender of the JWT is who they claim to be and that the token wasn’t tampererd with before it reached its destination.