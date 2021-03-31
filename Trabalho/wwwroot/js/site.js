var mask = {

    //Init
    init: function (o, f) {
        v_obj = o;
        v_fun = f;

        setTimeout("mask.execmasc()", 1);
    },

    //ExecMasc
    execmasc: function () {
        v_obj.value = v_fun(v_obj.value)
    },

    //Num
    num: function (v) {
        v = v.replace(/\D/g, "");

        return v;
    },



    
}
