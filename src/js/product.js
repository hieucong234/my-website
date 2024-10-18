var chatVisible = false;
var chatContainer = document.getElementById('chat-container');

function toggleChat() {
    chatVisible = !chatVisible;
    if (chatVisible) {
        chatContainer.style.display = 'block';
    } else {
        chatContainer.style.display = 'none';
    }
}

// Function to send a message
function sendMessage() {
    var messageInput = document.getElementById('message-input');
    var message = messageInput.value.trim();
    if (message !== '') {
        var chatContent = document.getElementById('chat-content');
        var messageElement = document.createElement('div');
        messageElement.textContent = message;
        messageElement.classList.add('message');
        chatContent.appendChild(messageElement);
        messageInput.value = ''; // Clear the input field after sending message
    }
}

function openForm() {
    document.getElementById("myForm").style.display = "block";
  }
  
  function closeForm() {
    document.getElementById("myForm").style.display = "none";
  }