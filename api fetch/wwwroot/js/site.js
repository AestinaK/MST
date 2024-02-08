const __ = document.querySelector.bind(document);
const _a = document.querySelectorAll.bind(document)


function previousNext(is_previous) {
    const currentPage = parseInt($('.pagination li.current').find('span').remove().end().text());
    let new_page_num = currentPage + 1;
    if (is_previous == !0) {
        new_page_num = currentPage - 1
    }
    navigate(new_page_num)
}

function navigate(new_page_num) {
    const pageNumberQueryName = __pageNumberPrefix ? __pageNumberPrefix + ".page" : "page";
    let parsedUrl = window.location.href;
    const queryString = location.search;
    const urlParams = new URLSearchParams(location.search);
    if (queryString == "") {
        parsedUrl += `?${pageNumberQueryName}=` + new_page_num
    } else {
        if (urlParams.has(pageNumberQueryName)) {
            parsedUrl = parsedUrl.split('?')[0];
            urlParams.delete(pageNumberQueryName);
            parsedUrl += "?" + urlParams + `&${pageNumberQueryName}=` + new_page_num
        } else {
            parsedUrl += `&${pageNumberQueryName}=` + new_page_num
        }
    }
    window.location.href = parsedUrl
}

window.__pageNumberPrefix ??= "";

$(() => {
    const pickers = $(".mb-nep-date-picker");
    const nepDatePickerHiddenElms = $(".mb-nep-date-picker-hidden-elm");

    pickers.nepaliDatePicker({
        dateFormat: "%y-%m-%d",
        closeOnDateSelect: true
    });

    pickers.on('dateChange', function(eventData) {
        const actualElm = __(`[name=${eventData.currentTarget.dataset.actualName}]`);
        if(!!actualElm) {
            const date = eventData.datePickerData.adDate;
            let value = "";
            if(date) {
                value = `${date.getFullYear()}-${date.getMonth() + 1}-${date.getDate()}`;
            }
            actualElm.value = value;
        }
    })

    nepDatePickerHiddenElms.on('change', (e) => {
        const value = e.target.value;
        if(!value) {
            return;
        }
        const displayElm = __(`[name='__${e.target.name}']`);
        const parts = value.replaceAll('/', '-').split("-");
        const { bsYear, bsMonth, bsDate } = calendarFunctions.getBsDateByAdDate(+parts[0], +parts[1], +parts[2]);
        displayElm.value = `${bsYear}-${bsMonth.toString().padStart(2,'0')}-${bsDate.toString().padStart(2,'0')}`;
    });

    $.extend({
        getUrlVars: function () {
            var vars = [], hash;
            var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
            for (var i = 0; i < hashes.length; i++) {
                hash = hashes[i].split('=');
                vars.push(hash[0]);
                vars[hash[0]] = hash[1]
            }
            return vars
        }, getUrlVar: function (name) {
            return $.getUrlVars()[name]
        }
    });
    $('.pagination-previous').on('click', function () {
        $('.pagination-previous a').removeAttr('href');
        previousNext(!0)
    });
    $('.pagination-next').on('click', function () {
        $('.pagination-next a').removeAttr('href');
        previousNext(!1)
    });
    $('.pagination li>a').on('click', function () {
        $(this).removeAttr('href');
        const pageNum = this.dataset.page ?? this.textContent;
        navigate(pageNum)
    });
});
