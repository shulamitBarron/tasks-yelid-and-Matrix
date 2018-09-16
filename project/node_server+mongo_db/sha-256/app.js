const {SHA256}=require("crypto-js");

// example to testing the hash
const message='Test hash sha256';
const hash=SHA256(message).toString();
console.log(`Message : ${message}`);
console.log(`Hash : ${hash}`);
