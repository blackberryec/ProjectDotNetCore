/**
 * author: Daniel Husar
 */

(function (window, document, $, undefined) {
  'use strict';


  $.fn.extend({
    mobileMenu: function (options) {

      var defaults = {
        openClass : 'menu-open',
        preventDefault: true,
        callback: function () {}
      };
      var settings = $.extend(defaults, options);

      var scrollPosition = 0;
      var $document = $('html');
      var $body = $(document.body);
      return this.on('click.menu', function (e) {

        if (settings.preventDefault) {
          e.preventDefault();
        }

        if (scrollPosition) {
          $document.toggleClass(settings.openClass); //hide menu first
          $body.scrollTop(scrollPosition);
          scrollPosition = 0;
        } else {
          var tempPosition = $body.scrollTop();
          $body.scrollTop(scrollPosition);
          scrollPosition = tempPosition;
          $document.toggleClass(settings.openClass); //show menu when all caculations are done
        }

        if (typeof settings.callback === 'function') {
          settings.callback.call(this, e);
        }

      });

    }
  });

}(this, this.document, this.jQuery));
