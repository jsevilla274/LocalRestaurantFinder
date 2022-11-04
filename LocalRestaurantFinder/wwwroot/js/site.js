// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function buildStarRating(rating) {
    let starsHTML = "";
    let fullCount = Math.floor(rating);
    let emptyCount = Math.floor(5 - rating);

    for (let i = 0; i < fullCount; i++) {
        starsHTML += '<i class="bi bi-star-fill"></i>';
    }
    if (rating > fullCount) {
        starsHTML += '<i class="bi bi-star-half"></i>';
    }
    for (let i = 0; i < emptyCount; i++) {
        starsHTML += '<i class="bi bi-star"></i>';
    }

    return starsHTML;
}

function redrawSearchResults(searchData) {
    let searchResultsContainer = $('#search-results-container');
    searchResultsContainer.empty();
    searchData.forEach((business) => {
        let fullAddress = business.location['display_address'].join(' ');
        searchResultsContainer.append(`
            <div class="card search-card">
                <h4 class="card-title">${business['name']}</h4>
                <p class="card-text">${fullAddress}</p>
                <p class="card-text">${business['display_phone']}</p>
                <p class="card-text">${buildStarRating(business['rating'])}</p>
            </div>
        `);
    });
}

function callSearchEndpoint(searchInput) {
    $.ajax({
        url: `${window.location.href}businesses`,
        dataType: 'json',
        data: {
            zipCode: searchInput
        },
    })
        .done((data, textStatus, jqXHR) => {
            redrawSearchResults(data);
        });
}


$("#search-submit-button").click((e) => {
    let searchInput = $('#search-text-input').val().trim();
    if (/^\d{5}$/.test(searchInput)) {
        callSearchEndpoint(searchInput);
    }
});