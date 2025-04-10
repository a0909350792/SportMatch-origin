﻿//日曆
document.addEventListener("DOMContentLoaded", () => {
    const monthYear = document.getElementById("monthYear");
    const calendarDays = document.querySelector(".calendar-days");
    const prevMonth = document.getElementById("prevMonth");
    const nextMonth = document.getElementById("nextMonth");

    let date = new Date();
    let currentYear = date.getFullYear();
    let currentMonth = date.getMonth();

    // 建立一個 Tooltip 元素
    const tooltip = document.createElement("div");
    tooltip.className = "calendar-tooltip";
    tooltip.style.display = "none";
    document.body.appendChild(tooltip);

    // 顯示 Tooltip 函數
    function showTooltip(e, text) {
        tooltip.textContent = text;
        tooltip.style.left = e.pageX + "px";
        tooltip.style.top = e.pageY - 40 + "px";
        tooltip.style.display = "block";
    }

    // 隱藏 Tooltip 函數
    function hideTooltip() {
        tooltip.style.display = "none";
    }
    function renderCalendar() {
        calendarDays.innerHTML = "";

        const firstDay = new Date(currentYear, currentMonth, 1);
        const lastDay = new Date(currentYear, currentMonth + 1, 0);

        const startDayOfWeek = firstDay.getDay(); // 星期幾開始
        const totalDaysInMonth = lastDay.getDate(); // 當月總天數

        // 前一個月的資訊
        const prevMonth = currentMonth === 0 ? 11 : currentMonth - 1;
        const prevYear = currentMonth === 0 ? currentYear - 1 : currentYear;
        const prevMonthTotalDays = new Date(prevYear, prevMonth + 1, 0).getDate();

        //補前一個月的尾巴
        for (let i = startDayOfWeek - 1; i >= 0; i--) {
            const day = prevMonthTotalDays - i;
            const dayElement = document.createElement("div");
            dayElement.textContent = day;
            dayElement.classList.add("dimmed"); // 加淡色樣式
            calendarDays.appendChild(dayElement);
        }

        //當月天數
        for (let day = 1; day <= totalDaysInMonth; day++) {
            const dayElement = document.createElement("div");
            dayElement.textContent = day;
            dayElement.style.position = "relative";

            let dateString = `${currentYear}-${String(currentMonth + 1).padStart(2, "0")}-${String(day).padStart(2, "0")}`;

            // 標記今天
            if (
                day === date.getDate() &&
                currentMonth === date.getMonth() &&
                currentYear === date.getFullYear()
            ) {
                dayElement.classList.add("today");
            }

            // 標記事件
            if (markedDates.includes(dateString)) {
                dayElement.classList.add("marked");
                const event = eventData.find(ev => ev.date === dateString);
                dayElement.addEventListener("click", (e) => {
                    const ripple = document.createElement("span");
                    ripple.classList.add("ripple");
                    ripple.style.left = `${e.offsetX}px`;
                    ripple.style.top = `${e.offsetY}px`;
                    dayElement.appendChild(ripple);
                    setTimeout(() => ripple.remove(), 600);
                    if (event) showTooltip(e, event.eventName);
                });
                dayElement.addEventListener("mouseleave", () => hideTooltip());
            }

            calendarDays.appendChild(dayElement);
        }

        //補下個月的開頭
        const currentCells = calendarDays.children.length;
        const nextDays = 42 - currentCells;

        for (let i = 1; i <= nextDays; i++) {
            const dayElement = document.createElement("div");
            dayElement.textContent = i;
            dayElement.classList.add("dimmed"); // 加淡色樣式
            calendarDays.appendChild(dayElement);
        }

        // 標題更新
        monthYear.textContent = `${currentYear}年 ${currentMonth + 1}月`;
    }

    prevMonth.addEventListener("click", () => {
        currentMonth--;
        if (currentMonth < 0) {
            currentMonth = 11;
            currentYear--;
        }
        renderCalendar();
    });

    nextMonth.addEventListener("click", () => {
        currentMonth++;
        if (currentMonth > 11) {
            currentMonth = 0;
            currentYear++;
        }
        renderCalendar();
    });
    let eventData = []; // 存放所有事件
    let markedDates = []; // 所有需標記的日期

    async function fetchAndMarkEventDates() {
        try {
            const res = await fetch("/Event/GetAllEventDates");
            const events = await res.json();

            eventData = events;
            markedDates = events.map(e => e.date);

            renderCalendar(); // 重新渲染日曆，會套用標記
        } catch (err) {
            console.error("活動日期資料載入失敗：", err);
        }
    }
    fetchAndMarkEventDates();
});
//倒數計時器
function initCountdownTimers() {
    var countdownElements = document.querySelectorAll(".countdown");

    function updateCountdown() {
        var now = new Date().getTime();

        countdownElements.forEach(function (element) {
            var targetTime = parseInt(element.getAttribute("data-target-time"), 10);
            var distance = targetTime - now;

            if (distance <= 0) {
                element.innerHTML = "賽事逾期";
                return;
            }

            var days = Math.floor(distance / (1000 * 60 * 60 * 24));
            var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
            var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
            var seconds = Math.floor((distance % (1000 * 60)) / 1000);

            days = String(days).padStart(2, '0');
            hours = String(hours).padStart(2, '0');
            minutes = String(minutes).padStart(2, '0');
            seconds = String(seconds).padStart(2, '0');

            element.innerHTML = days + "天 " + hours + "小時 " + minutes + "分 " + seconds + "秒";
        });
    }

    setInterval(updateCountdown, 1000);
    updateCountdown();
}
document.addEventListener("DOMContentLoaded", function () {
    initCountdownTimers();
});
//報名特效
document.addEventListener("DOMContentLoaded", function () {
    // 選取所有 class 為 join-btn 的按鈕
    document.querySelectorAll(".join-btn").forEach(function (button) {
        button.addEventListener("mouseover", function () {
            this.innerText = "快點擊我";
        });

        button.addEventListener("mouseout", function () {
            this.innerText = "立即報名";
        });
    });
    initJoinModalButtons();
});
//資料換頁功能
document.addEventListener("DOMContentLoaded", function () {
    console.log("Event.js 成功載入");

    const itemsPerPage = 5; // 每頁顯示的賽事數量
    let currentPage = 1; 
    //const eventsContainer = document.getElementById("events-container");
    const paginationContainer = document.getElementById("MyPagination");
    const eventItems = Array.from(document.querySelectorAll(".event-item"));
    const totalPages = Math.ceil(eventItems.length / itemsPerPage);
    function renderPagination() {
        //paginationContainer.innerHTML = ""; // 先清空按鈕
        //const totalVisibleButtons = 7; // 固定按鈕顯示數量，包括 ...

        // 建立「上一頁」按鈕
        const prevBtn = document.createElement("button");
        prevBtn.innerText = "« 上一頁";
        prevBtn.classList.add("page-btn", "prev-btn");
        prevBtn.disabled = currentPage === 1;
        prevBtn.addEventListener("click", function () {
            if (currentPage > 1) {
                currentPage--;
                updatePagination();
            }
        });
        paginationContainer.appendChild(prevBtn);

        //修正邏輯，處理當 totalPages < 7 的情況
        let startPage, endPage;

        if (totalPages < 7) {
            //如果總頁數小於 7，直接顯示所有頁碼，沒有 `...`
            startPage = 1;
            endPage = totalPages;
        } else {
            //原本的邏輯，當總頁數大於等於 7 才使用 `...`
            if (currentPage <= 3) {
                startPage = 1;
                endPage = 5;
            } else if (currentPage >= totalPages - 2) {
                startPage = totalPages - 4;
                endPage = totalPages;
            } else {
                startPage = currentPage - 1;
                endPage = currentPage + 1;
            }
        }

        if (startPage > 1) {
            addPageButton(1);
            if (startPage > 2) addEllipsis();
        }

        for (let i = startPage; i <= endPage; i++) {
            addPageButton(i);
        }

        if (endPage < totalPages) {
            if (endPage < totalPages - 1) addEllipsis();
            addPageButton(totalPages);
        }

        // 建立「下一頁」按鈕
        const nextBtn = document.createElement("button");
        nextBtn.innerText = "下一頁 »";
        nextBtn.classList.add("page-btn", "next-btn");
        nextBtn.disabled = currentPage === totalPages;
        nextBtn.addEventListener("click", function () {
            if (currentPage < totalPages) {
                currentPage++;
                updatePagination();
            }
        });
        paginationContainer.appendChild(nextBtn);

        // 先移除舊的 "共 xx 筆資料"
        const oldTotalRecords = document.querySelector(".total-records");
        if (oldTotalRecords) {
            oldTotalRecords.remove();
        }

        //新增「共 xx 筆資料」的顯示區塊
        const totalRecordsText = document.createElement("span");
        totalRecordsText.innerText = `共 ${eventItems.length} 筆資料`;
        totalRecordsText.classList.add("total-records");

        //放到「下一頁」按鈕的右邊
        paginationContainer.appendChild(totalRecordsText);
    }

    //新增頁碼按鈕的函式
    function addPageButton(page) {
        const btn = document.createElement("button");
        btn.innerText = page;
        btn.classList.add("page-btn");
        if (page === currentPage) btn.classList.add("active");

        btn.addEventListener("click", function () {
            currentPage = page;
            updatePagination();
        });

        paginationContainer.appendChild(btn);
    }
    //新增省略號 (...) 按鈕
    function addEllipsis() {
        const ellipsis = document.createElement("span");
        ellipsis.innerText = "...";
        ellipsis.classList.add("ellipsis");
        paginationContainer.appendChild(ellipsis);
    }

    function updatePagination() {
        console.log("執行 updatePagination，當前頁面：" + currentPage);
        eventItems.forEach((item, index) => {
            let shouldShow = index >= (currentPage - 1) * itemsPerPage && index < currentPage * itemsPerPage;
            console.log("項目 " + index + " 是否顯示：" + shouldShow);

            if (shouldShow) {
                item.style.display = "flex"; // 確保 `event-item` 顯示時保持 `flex`
            } else {
                item.style.display = "none"; // 隱藏其他項目
            }
        });

        renderPagination();
    }

    window.updatePagination = updatePagination; // 確保全域可存取

    updatePagination(); // 頁面載入時執行
});

    //輪播圖
    const track = document.querySelector('.EventCarousel-track');
    const prevButton = document.querySelector('.EventCarousel-button.prev');
    const nextButton = document.querySelector('.EventCarousel-button.next');
    const items = document.querySelectorAll('.EventCarousel-item');
    const indicators = document.querySelectorAll('.EventIndicator');

    let currentIndex = 0;

    // 更新輪播顯示和指示器樣式
    function updateCarousel() {
        const itemWidth = items[0].clientWidth;
        track.style.transform = `translateX(-${currentIndex * itemWidth}px)`;

        indicators.forEach((indicator, index) => {
            indicator.classList.toggle('active', index === currentIndex);
        });
    }
    // 下一張圖片
    nextButton.addEventListener('click', () => {
        currentIndex = (currentIndex + 1) % items.length;
        updateCarousel();
    });
    // 上一張圖片
    prevButton.addEventListener('click', () => {
        currentIndex = (currentIndex - 1 + items.length) % items.length;
        updateCarousel();
    });
    // 點擊指示器跳轉到對應圖片
    indicators.forEach((indicator) => {
        indicator.addEventListener('click', () => {
            currentIndex = parseInt(indicator.getAttribute('data-index'));
            updateCarousel();
        });
    });
    //輪播秒數設定
    setInterval(() => {
        nextButton.click();
    }, 8000);
    updateCarousel();
//彈窗開啟 / 關閉
function initJoinModalButtons() {
    const buttons = document.querySelectorAll(".open-modal");
    const modal = document.getElementById("modal-overlay");
    const modalTitle = document.getElementById("modal-title");
    const closeButton = document.querySelector(".close-btn");

    // 清除舊的事件（避免重複綁定）
    buttons.forEach(button => {
        button.replaceWith(button.cloneNode(true));
    });

    // 重新選取 clone 後的按鈕
    document.querySelectorAll(".open-modal").forEach(button => {
        button.addEventListener("click", function () {
            const matchTitle = this.getAttribute("data-title");
            modalTitle.textContent = matchTitle + " 報名表單";
            modal.style.display = "flex";
        });
    });

    // 關閉彈窗
    closeButton?.addEventListener("click", function () {
        modal.style.display = "none";
    });

// 點擊彈窗外部關閉(不合理，先不要)
    modal?.addEventListener("click", function (event) {
        if (event.target === modal) {
            alert("請透過右上角 X 關閉表單");
        }
    });
}
//篩選欄位
document.addEventListener("DOMContentLoaded", () => {
    const filterForm = document.getElementById("filterForm");

    // 篩選提交時，送出頁數 = 1
    filterForm?.addEventListener("submit", function (e) {
        e.preventDefault();
        submitWithPage(1);
    });

    // 點擊任何分頁按鈕（包括上一頁、下一頁）
    document.addEventListener("click", function (e) {
        if (e.target.classList.contains("page-btn")) {
            const page = e.target.dataset.page;
            if (page) {
                submitWithPage(page);
            }
        }
    });

    function submitWithPage(page) {
        const formData = new FormData(filterForm);
        formData.append("Page", page);

        fetch("/Event/FilterEvents", {
            method: "POST",
            body: new URLSearchParams(formData)
        })
            .then(res => res.text())
            .then(html => {
                document.getElementById("events-container").innerHTML = html;

                initCountdownTimers();
                initJoinModalButtons();     

                window.scrollTo({
                    top: document.getElementById("events-container").offsetTop - 100,
                    behavior: "smooth"
                });
            })
            .catch(err => {
                console.error("分頁載入失敗：", err);
            });
    }
});

