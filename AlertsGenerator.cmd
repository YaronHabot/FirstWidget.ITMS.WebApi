curl -X POST "https://localhost:5001/NCDB" -H  "accept: text/plain" -H  "Content-Type: application/json" -d "{\"ssn\":\"111223333\",\"message\":\"Criminal\"}"

TIMEOUT  2
curl -X POST "https://localhost:5001/CB" -H  "accept: text/plain" -H  "Content-Type: application/json" -d "{\"ssn\":\"111224444\",\"message\":\"Bankrupt\"}"

TIMEOUT  2
curl -X POST "https://localhost:5001/CB" -H  "accept: text/plain" -H  "Content-Type: application/json" -d "{\"ssn\":\"111224444\",\"message\":\"Debt\"}"