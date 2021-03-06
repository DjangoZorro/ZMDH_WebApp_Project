"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
var url = window.location.href;
var params = url.split('/');
var id=params[5];

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;
connection.on("Send", function (message) {
    

        divc = "<div>.container.content-rows";
        var divc = document.createElement("div");
        divc.className = "d-flex flex-row p-3";
        document.getElementById('messagesList').appendChild(divc);
        createNestedDivs(divc);
  
    function createNestedDivs(selector) {
      function appendToNode(node) {
        // ideally content would also be a Node, but for simplicity, 
        // I'm assuming it's a string. 
        var inner = document.createElement('div');
        inner.className = "chat ml-2 p-3";
        inner.textContent = `${message}`;
        node.appendChild(inner);
      }
  
      if (selector instanceof Node) {
        appendToNode(selector, "div");
        return;
      }
  
      var selected = Array.prototype.slice.call(document.querySelectorAll(selector));
      selected.forEach(function(el) {
        appendToNode(el, "div");
      });
    }
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.

    
    document.getElementById('messagesList').scrollIntoView(false);
    
});

connection.start().then( async function () {
    document.getElementById("sendButton").disabled = false;

    if(id != null){
      console.log(id);
      console.log(document.getElementById("group-name").textContent);
      var user = document.getElementById("userInput").value;
      var groupName = id;
      
      try {
          await connection.invoke("AddToGroup",user, groupName);
      }
      catch (e) {
          console.error(e.toString());
      }
      event.preventDefault();
    }
}).catch(function (err) {
    return console.error(err.toString());
});



function anoniem() {

 var user = document.getElementById("userInput");
 let temp = document.getElementById("temp");
  if(document.getElementById("anoniem").checked){
    temp.value = user.value;
    user.value = 'Anoniem';
  }else{
    user.value= temp.value ;
  }

};
async function group() {

console.log(document.getElementById("group-name").textContent);
  var user = document.getElementById("userInput").value;
  var groupName = document.getElementById("group-name").textContent;
  
  try {
      await connection.invoke("AddToGroup",user, groupName);
  }
  catch (e) {
      console.error(e.toString());
  }
  event.preventDefault();
};

// neww 

document.getElementById("sendButton").addEventListener("click", async (event) => {
  var user = document.getElementById("userInput").value;
  var groupName = id;
  var groupMsg = document.getElementById("messageInput").value;
  if(document.getElementById("messageInput").value != ""){
  try {
      await connection.invoke("SendMessageToGroup", user, groupName, groupMsg);
  }
  catch (e) {
      console.error(e.toString());
  }
  event.preventDefault();
  document.getElementById('messageInput').value = '';
}
});


document.getElementById("join-group").addEventListener("click", async (event) => {
  
});
document.getElementById("leave-group").addEventListener("click", async (event) => {
  var user = document.getElementById("userInput").value;
  var groupName = id;
  console.log(groupName);
  try {
      await connection.invoke("RemoveFromGroup",user, groupName);
      location.href = "/Home/Chat";
  }
  catch (e) {
      console.error(e.toString());
  }
  event.preventDefault();
});
// We need an async function in order to use await, but we want this code to run immediately,
// so we use an "immediately-executed async function"
// (async () => {
//   try {
//       await connection.start();
//   }
//   catch (e) {
//       console.error(e.toString());
//   }
// })();