// JavaScript Document
$(document).ready(function(){
	$(".list").click(function() {
		$("div.pro-new").removeClass("pro-new").addClass("pro-new-list");
	});
	$(".grid").click(function() { 
		$("div.pro-new-list").removeClass("pro-new-list").addClass("pro-new");
	});
	
	
	$('.cats').click(function(){
		$('.show-cat').slideToggle();
	});
	$('.close').click(function(){
		$('.show-cat').slideUp();
	});
	
	$('.categories').hide();
	$('.cats').mouseover(function(){
		$('.categories').slideDown();						  
	});
	$('.all-cat').mouseleave(function(){
		$('.categories').slideUp();						  
	});
	
	
	$('.cat-menus li a').mouseover(function(){
		$(this).parent().children('.sub-catlist').slideDown();
	});

	$('.cat-menus li').mouseleave(function(){
		$(this).children('.sub-catlist').slideUp();
	});
	
	$('.cat-menus li .sub-catlist').mouseover(function(){
		$(this).parent().children('a').addClass('highlight');												   
	});
	$('.cat-menus li .sub-catlist').mouseout(function(){
		$(this).parent().children('a').removeClass('highlight');												   
	});

    var url = $(location).attr("href"); 
    if (url.indexOf("Ads") > -1)
    {
        $('#lnkAds').parent().addClass("active");
    }
    else if (url.indexOf("Banner") > -1) {
        $('#lnkBanner').parent().addClass("active");
    }
    else if (url.indexOf("Password") > -1) {
        $('#lnkPwd').parent().addClass("active");
    }
    else if (url.indexOf("Settings") > -1) {
        $('#lnkSettings').parent().addClass("active");
    }
    else if (url.indexOf("Tax") > -1) {
        $('#lnkTax').parent().addClass("active");
    }
    else if (url.indexOf("Shipping") > -1) {
        $('#lnkShip').parent().addClass("active");
    }
  
    else if (url.indexOf("Cms") > -1) {
        $('#lnkCms').parent().addClass("active");
    }
    else if (url.indexOf("HomeMenu") > -1) {
        $('#lnkHomeMenu').parent().addClass("active");
    }
    else if (url.indexOf("Gateway") > -1) {
        $('#lnkGateway').parent().addClass("active");
    }
    else if (url.indexOf("Categories") > -1) {
        $('#lnkCategories').parent().addClass("active");
    }
    else if (url.indexOf("Brands") > -1) {
        $('#lnkBrands').parent().addClass("active");
    }
    else if (url.indexOf("ProductFilter") > -1) {
        $('#lnkProductFilter').parent().addClass("active");
    }
    else if (url.indexOf("Product") > -1) {
        $('#lnkProduct').parent().addClass("active");
    }
   
    else if (url.indexOf("Users") > -1) {
        $('#lnkUsers').parent().addClass("active");
    }
    else if (url.indexOf("Orders") > -1) {
        $('#lnkOrders').parent().addClass("active");
    }
    else if (url.indexOf("Newsletters") > -1) {
        $('#lnkNewsletters').parent().addClass("active");
    }
    else {
    }
});