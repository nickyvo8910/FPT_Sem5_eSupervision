var Script = function () {

    //morris chart

    $(function () {
      // data stolen from http://howmanyleft.co.uk/vehicle/jaguar_'e'_type


      Morris.Bar({
        element: 'hero-bar',
        data: [
          {device: 'Supervisor 1', geekbench: 136},
          {device: 'Supervisor 2', geekbench: 137},
          {device: 'Supervisor 3', geekbench: 275},
          {device: 'Supervisor 4', geekbench: 380},
          {device: 'Supervisor 5', geekbench: 655},
          {device: 'Supervisor 6', geekbench: 1571},
		  {device: 'Supervisor 7', geekbench: 136},
          {device: 'Supervisor 8', geekbench: 137},
          {device: 'Supervisor 9', geekbench: 275},
          {device: 'Supervisor 10', geekbench: 1571}
        ],
        xkey: 'device',
        ykeys: ['geekbench'],
        labels: ['Geekbench'],
        barRatio: 0.4,
        xLabelAngle: 35,
        hideHover: 'auto',
        barColors: ['#BFC2CD']
      });

      $('.code-example').each(function (index, el) {
        eval($(el).text());
      });
    });

}();




