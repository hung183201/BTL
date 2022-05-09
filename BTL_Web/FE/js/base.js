$(document).ready(function () {
  //active ở menu
  $('header nav  ul li').click(function () {
    $('header ul li').removeClass('active');
    $(this).addClass('active')
  })
  $('.mb_menu  ul li').click(function () {
    $('.mb_menu ul li').removeClass('active');
    $(this).addClass('active')
  })
  //modal search
  $('.icon-search').click(function () {
    $('.modalShow').show();
    $('.modal__search').show();
    $('.modal__login').hide();
    $('.modal__register').hide();
  })
  $('.icon-login').click(function () {
    $('.modalShow').show();
    $('.modal__search').hide();
    $('.modal__login').show();
    $('.modal__register').hide();
  })
  $('.close-search').click(function () {
    $('.modalShow').hide();
  })
  $('.modalShow .overlay').click(function () {
    $('.modalShow').hide();
  })
  $('.btnregis').click(function () {
    $('.modal__search').hide();
    $('.modal__login').hide();
    $('.modal__register').show();
  })
  $('.btnlogin').click(function () {
    $('.modal__search').hide();
    $('.modal__login').show();
    $('.modal__register').hide();
  })
  $('.classify li').click(function () {
    $('.classify li').removeClass('active');
    $(this).addClass('active');
    console.log(1);
  })
  $('.mb_menu .overlay').click(function () {
    $('.mb_menu').hide();
  })
  $('.mb_menu i').click(function () {
    $('.mb_menu').hide();
  })
  $('.mb-menu .icon-menu').click(function () {
    $('.mb_menu').show();
  })
  $('.menu1').click(function () {
    $('.mb-menu2').toggle();
  })
  $('.product__promotion').slick({
    infinite: true,
    slidesToShow: 4,
    slidesToScroll: 4,
    autoplay: true,
    autoplaySpeed: 2000,
    responsive: [
      {
        breakpoint: 1400,
        settings: {
          slidesToShow: 3,
          slidesToScroll: 3,
          infinite: true,
          dots: true
        }
      },
      {
        breakpoint: 600,
        settings: {
          slidesToShow: 2,
          slidesToScroll: 2
        }
      },
      {
        breakpoint: 575.98,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1
        }
      }]
  });

  $('.product__promotions').slick({
    infinite: true,
    slidesToShow: 4,
    slidesToScroll: 4,
    autoplay: true,
    autoplaySpeed: 2000,
    responsive: [
      {
        breakpoint: 1400,
        settings: {
          slidesToShow: 3,
          slidesToScroll: 3,
          infinite: true,
          dots: true
        }
      },
      {
        breakpoint: 600,
        settings: {
          slidesToShow: 2,
          slidesToScroll: 2
        }
      },
      {
        breakpoint: 575.98,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1
        }
      }]
  });
  $('.brand').slick({
    infinite: true,
    slidesToShow: 6,
    slidesToScroll: 2,
    autoplay: true,
    autoplaySpeed: 1000,
    responsive: [
      {
        breakpoint: 1024,
        settings: {
          slidesToShow: 3,
          slidesToScroll: 3,
          infinite: true,
          dots: true
        }
      },
      {
        breakpoint: 600,
        settings: {
          slidesToShow: 2,
          slidesToScroll: 2
        }


      }]
  });
});

const toTop = document.querySelector("#ScrollTop");
window.addEventListener("scroll", () => {
  if (window.pageYOffset > 200) {
    toTop.classList.add("active");
  } else {
    toTop.classList.remove("active");
  }
})
$("#ScrollTop").click(function () {
  window.scrollTo({ top: 0, behavior: 'smooth' });
});

window.addEventListener("scroll", () => {
  if (window.pageYOffset > 200) {
    $('header').addClass('header_scroll')
  } else {
    $('header').removeClass('header_scroll')
  }
})

$('.close').click(function () {
  let parent = $(this).parent();
  parent.remove();
})
$('.tru').click(function () {
  let res = $(this).siblings('.input').val();
  console.log(res);
  if (res > 1) {
    res = parseInt(res) - 1;
  };
  $(this).siblings('.input').val(res);
});
$('.cong').click(function () {
  let res = $(this).siblings('.input').val();
  res = parseInt(res) + 1;
  $(this).siblings('.input').val(res);
});
$('.pagination ul .page').click(function () {
  $('.pagination ul .page').removeClass('active');
  $(this).addClass('active')
})
//search
function setList(list) {
  $('.list-product').html('');
  for (let i = 0; i < list.length; i++) {
    $('.list-product').append(list[i]);
  }
}
$('.price li input[type=radio]').click(function () {
  let val = $(this).attr('value');
  let minPrice = 0;
  let maxPrice = 0;
  if (val == 1) {
    minPrice = 0;
    maxPrice = 100000;
  }
  if (val == 2) {
    minPrice = 100000;
    maxPrice = 500000;
  }
  if (val == 3) {
    minPrice = 500000;
    maxPrice = 0;
  }
  console.log(val);
  let arr = [];
  $('.prd').each(function () {
    var price = $(this).children().children().children('.tien').text()
    var lst = price.split(',')
    var src = lst.join('')
    if (minPrice <= src && (src < maxPrice || maxPrice == 0)) {
      let div = $(this);
      arr.push(div);
    }
    setList(arr);
  })
  console.log(arr);
})
$('.modal__register button').click(function(){
   $('.register__input input').val(" ");
})

$('.btnlogin').click(function(){
  $('.icon-login').hide();
  $('#username').show();
})

$('.store__left ul li a').click(function(){
  $('.store__left ul li a').removeClass('active')
  $(this).addClass('active')
})
