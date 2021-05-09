echo Employee get valid SSN
curl -X GET "https://localhost:5001/Employee?ssn=111223333" -H  "accept: text/plain" -k

echo Employee get invalid SSN
curl -X GET "https://localhost:5001/Employee?ssn=1112" -H  "accept: text/plain" -k

echo Employee update valid SSN
curl -X PUT "https://localhost:5001/Employee" -H  "accept: text/plain" -H  "Content-Type: application/json" -d "{\"ssn\":\"111223333\",\"firstName\":\"Yaron\",\"lastName\":\"Habot\",\"address\":\"1 Main st.\",\"city\":\"Orlando\",\"state\":\"FL\"}" -k

echo Employee update invalid SSN
curl -X PUT "https://localhost:5001/Employee" -H  "accept: text/plain" -H  "Content-Type: application/json" -d "{\"ssn\":\"1112\",\"firstName\":\"Yaron\",\"lastName\":\"Habot\",\"address\":\"1 Main st.\",\"city\":\"Orlando\",\"state\":\"FL\"}" -k

echo Employee insert valid SSN
curl -X POST "https://localhost:5001/Employee" -H  "accept: text/plain" -H  "Content-Type: application/json" -d "{\"ssn\":\"111223333\",\"firstName\":\"Yaron\",\"lastName\":\"Habot\",\"address\":\"1 Main st.\",\"city\":\"Orlando\",\"state\":\"FL\"}" -k

echo Employee insert invalid SSN
curl -X POST "https://localhost:5001/Employee" -H  "accept: text/plain" -H  "Content-Type: application/json" -d "{\"ssn\":\"1112\",\"firstName\":\"Yaron\",\"lastName\":\"Habot\",\"address\":\"1 Main st.\",\"city\":\"Orlando\",\"state\":\"FL\"}" -k

echo Employee delete valid SSN
curl -X DELETE "https://localhost:5001/Employee?ssn=111223333" -H  "accept: text/plain" -k

echo Employee delete invalid SSN
curl -X DELETE "https://localhost:5001/Employee?ssn=1112" -H  "accept: text/plain" -k

echo National Crime Database
curl -X POST "https://localhost:5001/NCDB" -H  "accept: text/plain" -H  "Content-Type: application/json" -d "{\"ssn\":\"111223333\",\"message\":\"Criminal\"}" -k

echo Credit Bureau
curl -X POST "https://localhost:5001/CB" -H  "accept: text/plain" -H  "Content-Type: application/json" -d "{\"ssn\":\"111223333\",\"message\":\"Bankrupt\"}" -k