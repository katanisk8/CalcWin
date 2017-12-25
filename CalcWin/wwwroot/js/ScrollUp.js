<script>
    function animateScrollTop(target, duration) {
        duration = duration || 16;

    var $window = $(window);
        var scrollTopProxy = {value: $window.scrollTop() };
        var expectedScrollTop = scrollTopProxy.value;

        if (scrollTopProxy.value != target) {
        $(scrollTopProxy).animate(
            { value: target },
            {
                duration: duration,

                step: function (stepValue) {
                    var roundedValue = Math.round(stepValue);
                    if ($window.scrollTop() !== expectedScrollTop) {
                        $(scrollTopProxy).stop();
                    }
                    $window.scrollTop(roundedValue);
                    expectedScrollTop = roundedValue;
                },

                complete: function () {
                    if ($window.scrollTop() != target) {
                        setTimeout(function () {
                            animateScrollTop(target);
                        }, 16);
                    }
                }
            }
        );
    }
    }
</script>