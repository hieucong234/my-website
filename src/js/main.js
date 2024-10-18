let slideIndex = 1;
      showSlides(slideIndex);
      
      function plusSlides(n) {
        showSlides(slideIndex += n);
      }
      
      function currentSlide(n) {
        showSlides(slideIndex = n);
      }
      
      function showSlides(n) {
        let i;
        let slides = document.getElementsByClassName("mySlides");
        let dots = document.getElementsByClassName("dot");
        if (n > slides.length) {slideIndex = 1}    
        if (n < 1) {slideIndex = slides.length}
        for (i = 0; i < slides.length; i++) {
          slides[i].style.display = "none";  
        }
        for (i = 0; i < dots.length; i++) {
          dots[i].className = dots[i].className.replace(" active", "");
        }
        slides[slideIndex-1].style.display = "block";  
        dots[slideIndex-1].className += " active";
      }

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



// Lấy phần tử modal, hình ảnh, và nút đóng
var modal = document.getElementById("myModal");
var img = document.getElementById("myImg");
var modalImg = document.getElementById("img01");
var closeButton = document.getElementsByClassName("close")[0];

// Gán src của hình ảnh vào phần tử modal khi nhấp vào ảnh nhỏ
img.onclick = function(){
  modal.style.display = "block";
  modalImg.src = this.src;
}

// Đóng modal khi người dùng nhấn vào nút "x"
closeButton.onclick = function() {
  modal.style.display = "none";
}

// Hiển thị modal ở giữa màn hình khi trang được tải
window.onload = function() {
  modal.style.display = "block";
  modal.style.alignItems = "center";
}


function openForm() {
  document.getElementById("myForm").style.display = "block";
}

function closeForm() {
  document.getElementById("myForm").style.display = "none";
}




function hide_float_right() {
  var content = document.getElementById('float_content_right');
  var hide = document.getElementById('hide_float_right');
}

function myF(){
  onl.style.display = "block"; 
}

function un(){
  onl.style.display = "none";
}