const express=require("express");
const app=express();
app.get("/test",(req,res)=>{
    res.sendFile("C:\\Users\\seldat\\Desktop\\new\\view\\index.html");
});
//enable all the files in the folder use
app.use(express.static("C:\\Users\\seldat\\Desktop\\new\\view"));
app.listen(4000,console.log("ok"));