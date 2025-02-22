var SinglePage = {};

SinglePage.LoadModal = function () {
    var url = window.location.hash.toLowerCase();
    if (!url.startsWith("#showmodal")) {
        return;
    }
    url = url.split("showmodal=")[1];
    $.get(url,
        null,
        function (htmlPage) {
            $("#ModalContent").html(htmlPage);
            const container = document.getElementById("ModalContent");
            const forms = container.getElementsByTagName("form");
            const newForm = forms[forms.length - 1];
            $.validator.unobtrusive.parse(newForm);
            showModal();
        }).fail(function (error) {
            $.Notification.autoHideNotify('error', 'top center', "خطایی رخ داده است. لطفا با مدیر سیستم تماس بگیرید."); 

        });
};

function showModal() {
    $("#MainModal").modal("show");
}

function hideModal() {
    $("#MainModal").modal("hide");
}
$(document).ready(function () {
    window.onhashchange = function () {
        SinglePage.LoadModal();
    };
    $("#MainModal").on("shown.bs.modal",
        function () {
            window.location.hash = "##";
            $('.persianDateInput').persianDatepicker({
                format: 'YYYY/MM/DD',
                autoClose: true
            });
            $('.inputFile').on('change', function (event) {
                const file = event.target.files[0];
                if (file) {
                    const reader = new FileReader();
                    reader.onload = function (e) {
                        $('#preview').attr('src', e.target.result).show();
                    }
                    reader.readAsDataURL(file);
                }
            });
            var src = $('#preview').attr('src');
            if (!src || src === "") {
                $('#preview').css("display","none")
            } else {
                $('#preview').css("display", "block")
            }
            $('.inputFile1').on('change', function (event) {
                const file = event.target.files[0];
                if (file) {
                    const reader = new FileReader();
                    reader.onload = function (e) {
                        $('#preview1').attr('src', e.target.result).show();
                    }
                    reader.readAsDataURL(file);
                }
            });
            var src = $('#preview1').attr('src');
            if (!src || src === "") {
                $('#preview1').css("display", "none")
            } else {
                $('#preview1').css("display", "block")
            }
        });

    $(document).on("submit",
        'form[data-ajax="true"]',
        function (e) {
            e.preventDefault();
            var form = $(this);
            const method = form.attr("method").toLocaleLowerCase();
            const url = form.attr("action");
            var action = form.attr("data-action");

            if (method === "get") {
                const data = form.serializeArray();
                $.get(url,
                    data,
                    function (data) {
                        CallBackHandler(data, action, form);
                    });
            } else {
                var formData = new FormData(this);
                $.ajax({
                    url: url,
                    type: "post",
                    data: formData,
                    enctype: "multipart/form-data",
                    dataType: "json",
                    processData: false,
                    contentType: false,
                    success: function (data) {
                        CallBackHandler(data, action, form);
                    },
                    error: function (data) {
                        $.Notification.autoHideNotify('error', 'top center', "خطایی رخ داده است. لطفا با مدیر سیستم تماس بگیرید."); 
                    }
                });
            }
            return false;
        });
});

function CallBackHandler(data, action, form) {
    switch (action) {
        case "Message":
            $.Notification.autoHideNotify('info', 'top center', data.massage);
            break;
        case "Refresh":
           
            if (data.isSuccess) {
                $.Notification.autoHideNotify('success', 'top center', 'موفق', data.massage);
                setTimeout(function () {
                    window.location.reload();
                }, 500);
               
            } else {
                $.Notification.autoHideNotify('error', 'top center', 'ناموفق', data.massage);
            }
            break;
        case "RefereshList":
            {
                hideModal();
                const refereshUrl = form.attr("data-refereshurl");
                const refereshDiv = form.attr("data-refereshdiv");
                get(refereshUrl, refereshDiv);
            }
            break;
        case "setValue":
            {
                const element = form.data("element");
                $(`#${element}`).html(data);
            }
            break;
        default:
    }
}

function get(url, refereshDiv) {
    const searchModel = window.location.search;
    $.get(url,
        searchModel,
        function (result) {
            $("#" + refereshDiv).html(result);
        });
}

function makeSlug(source, dist) {
    const value = $('#' + source).val();
    $('#' + dist).val(convertToSlug(value));
}

//var convertToSlug = function (str) {
//    var $slug = '';
//    const trimmed = $.trim(str);
//    $slug = trimmed.replace(/[^a-z0-9-آ-ی-]/gi, '-').replace(/-+/g, '-').replace(/^-|-$/g, '');
//    return $slug.toLowerCase();
//};
var convertToSlug = function (str) {
    var $slug = '';
    const trimmed = $.trim(str);
    // افزودن محدوده کاراکترهای سیریلیک \u0400-\u04FF
    $slug = trimmed.replace(/[^a-z0-9\u0600-\u06FF\u0400-\u04FF-]/gi, '-')
        .replace(/-+/g, '-')
        .replace(/^-|-$/g, '');
    return $slug.toLowerCase();
};
function checkSlugDuplication(url, dist) {
    const slug = $('#' + dist).val();
    const id = convertToSlug(slug);
    $.get({
        url: url + '/' + id,
        success: function (data) {
            if (data) {

                $.Notification.autoHideNotify('error', 'top center', "خطا", "اسلاگ نمی تواند تکراری باشد"); 
               
            }
        }
    });
}

function fillField(source, dist) {
    const value = $('#' + source).val();
    $('#' + dist).val(value);
}

function fillFieldDiscriptioToMeta(source, dist) {
    const value = $('#' + source).val();
    const limitedValue = value.substring(0, 150); // محدود کردن به 150 کاراکتر
    $('#' + dist).val(limitedValue);
}



$(document).on("click",
    'button[data-ajax="true"]',
    function () {
        const button = $(this);
        const form = button.data("request-form");
        const data = $(`#${form}`).serialize();
        let url = button.data("request-url");
        const method = button.data("request-method");
        const field = button.data("request-field-id");
        if (field !== undefined) {
            const fieldValue = $(`#${field}`).val();
            url = url + "/" + fieldValue;
        }
        if (button.data("request-confirm") == true) {
            if (confirm("آیا از انجام این عملیات اطمینان دارید؟")) {
                handleAjaxCall(method, url, data);
            }
        } else {
            handleAjaxCall(method, url, data);
        }
    });

function handleAjaxCall(method, url, data) {
    if (method === "post") {
        $.post(url,
            data,
            "application/json; charset=utf-8",
            "json",
            function (data) {

            }).fail(function (error) {
                $.Notification.autoHideNotify('error', 'top center', "خطایی رخ داده است. لطفا با مدیر سیستم تماس بگیرید."); 
            });
    }
}

jQuery.validator.addMethod("maxFileSize",
    function (value, element, params) {
        var size = element.files[0].size;
        var maxSize = 3 * 1024 * 1024;
        if (size > maxSize)
            return false;
        else {
            return true;
        }
    });

jQuery.validator.unobtrusive.adapters.addBool("maxFileSize");

jQuery.validator.addMethod("fileExtensionLimited",
    function (value, element, params) {
        debugger;
        var extentions = [".jpeg", ".png", ".webp", ".jpg"]
        var ext = value.split('.').pop();
     
        for (i = 0; i <= extentions.count; i++) {
            if (extentions[i] == ext)
                return true;
            else {
                return false;
            }
        }
    });
jQuery.validator.unobtrusive.adapters.addBool("fileExtensionLimited");


