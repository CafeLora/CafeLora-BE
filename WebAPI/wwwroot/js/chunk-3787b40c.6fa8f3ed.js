(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["chunk-3787b40c"],{"1fb9":function(e,t,n){},"38b4":function(e,t,n){"use strict";n("1fb9")},"408a":function(e,t,n){var c=n("e330");e.exports=c(1..valueOf)},5899:function(e,t){e.exports="\t\n\v\f\r                　\u2028\u2029\ufeff"},"58a8":function(e,t,n){var c=n("e330"),a=n("1d80"),o=n("577e"),i=n("5899"),r=c("".replace),l="["+i+"]",s=RegExp("^"+l+l+"*"),u=RegExp(l+l+"*$"),d=function(e){return function(t){var n=o(a(t));return 1&e&&(n=r(n,s,"")),2&e&&(n=r(n,u,"")),n}};e.exports={start:d(1),end:d(2),trim:d(3)}},"5a25":function(e,t,n){"use strict";n.r(t);var c=n("7a23"),a=Object(c["m"])("h1",null,"REPORTE DE EVALUACIONES",-1),o=Object(c["m"])("br",null,null,-1),i=Object(c["m"])("span",null,"Escriba la obra que desea buscar: ",-1),r=Object(c["m"])("br",null,null,-1),l=Object(c["m"])("br",null,null,-1),s=Object(c["m"])("span",null,"Seleccione la lista que desea buscar : ",-1);function u(e,t,n,u,d,b){var f=Object(c["O"])("confirmation-modal"),O=Object(c["O"])("modal"),j=Object(c["O"])("a-select-option"),m=Object(c["O"])("a-select"),h=Object(c["O"])("grid");return Object(c["G"])(),Object(c["l"])(c["b"],null,[Object(c["p"])(f,{error:null,show:e.showModalConfirmation,title:e.modalTitle,massiveDelete:e.massiveDelete,onCancel:e.closeModal},null,8,["show","title","massiveDelete","onCancel"]),Object(c["p"])(O,{show:!!e.message,title:e.message,onClose:e.handleError,error:e.error,loading:e.loading},null,8,["show","title","onClose","error","loading"]),Object(c["m"])("section",{id:"main",class:Object(c["x"])({expand:e.expand})},[a,o,i,Object(c["ab"])(Object(c["m"])("input",{type:"text",name:"txtobra",id:"txtobra","onUpdate:modelValue":t[0]||(t[0]=function(t){return e.filtro_obra=t})},null,512),[[c["V"],e.filtro_obra]]),r,l,s,Object(c["p"])(m,{"default-value":"TODOS",style:{width:"300px"},onChange:e.changeFiltroListaVerificacion},{default:Object(c["Z"])((function(){return[(Object(c["G"])(!0),Object(c["l"])(c["b"],null,Object(c["M"])(e.itemsListaVerificacion,(function(e,t){return Object(c["G"])(),Object(c["j"])(j,{key:t,value:e.nombre},{default:Object(c["Z"])((function(){return[Object(c["o"])(Object(c["Q"])(e.nombre),1)]})),_:2},1032,["value"])})),128))]})),_:1},8,["onChange"]),Object(c["p"])(h,{dataSource:e.dataSource,columns:e.columns,actions:e.actions,rows:5,onMovePage:e.movePage,onSelectedList:e.selectedList},null,8,["dataSource","columns","actions","onMovePage","onSelectedList"])],2)],64)}var d=n("1da1"),b=(n("96cf"),n("d3b7"),n("99af"),n("2fc2")),f=n("b7ff"),O=n("9fbc"),j=n("5c40"),m=n("705f"),h=n("d43e"),p="",v=Object(j["s"])({components:{Grid:O["a"],ConfirmationModal:f["a"],Modal:m["a"]},computed:{evaluacion:function(){return this.$store.getters["evaluacionModule/obtenerEvaluacion"]}},data:function(){return{dataSource:Object(h["a"])(),columns:b["e"],actions:[{icon:"fas fa-eye",type:b["d"].EDIT,method:this.edit}],filtro_obra:"",filtro_lista_verificacion:"",itemsListaVerificacion:[{id:"",nombre:"TODOS"},{id:1,nombre:"ISO 45002"},{id:1,nombre:"LEY Nº 29783  Ley de Seguridad y Salud en el Trabajo"}],modalTitle:"",showModalConfirmation:!1,id:"",entity:"",message:null,loading:!1,error:!1,entityList:[],massiveDelete:!1,expand:!1,page:1,quantity:5}},watch:{filtro_obra:function(e){var t=this;e&&(p&&clearTimeout(p),p=setTimeout((function(){t.listEvaluaciones()}),500))}},methods:{changeFiltroListaVerificacion:function(){var e=arguments.length>0&&void 0!==arguments[0]?arguments[0]:"";this.filtro_lista_verificacion=e,this.listEvaluaciones()},movePage:function(e){this.page=e,this.listEvaluaciones()},expandMain:function(e){this.expand=!e},selectedList:function(e){this.entityList=e},handleError:function(){this.message=null},closeModal:function(){this.showModalConfirmation=!1},listEvaluaciones:function(){var e=this;return Object(d["a"])(regeneratorRuntime.mark((function t(){var n;return regeneratorRuntime.wrap((function(t){while(1)switch(t.prev=t.next){case 0:return t.prev=0,t.next=3,fetch("".concat(b["b"],"evaluacion/listado?page=").concat(e.page,"&quantity=").concat(e.quantity,"&obra=").concat(e.filtro_obra,"&listVerif=").concat(e.filtro_lista_verificacion),{method:"GET",headers:new Headers({"Content-Type":"application/json",Authorization:"Bearer "+localStorage.getItem("token")})});case 3:return n=t.sent,t.next=6,n.json();case 6:e.dataSource=t.sent,console.log("this.dataSource"),console.log(e.dataSource),t.next=14;break;case 11:t.prev=11,t.t0=t["catch"](0),console.log(t.t0);case 14:case"end":return t.stop()}}),t,null,[[0,11]])})))()},edit:function(e,t,n){this.evaluacion.action="visualizar",this.$router.push("/evaluacion/".concat(t))}},mounted:function(){var e=this;Object(d["a"])(regeneratorRuntime.mark((function t(){return regeneratorRuntime.wrap((function(t){while(1)switch(t.prev=t.next){case 0:return t.next=2,e.listEvaluaciones();case 2:case"end":return t.stop()}}),t)})))()}}),g=(n("a938"),n("6b0d")),y=n.n(g);const k=y()(v,[["render",u]]);t["default"]=k},"5ef3":function(e,t,n){},"682b":function(e,t,n){"use strict";function c(e){var t=new Date(e),n=Date.now()-t.getTime(),c=new Date(n);return Math.abs(c.getUTCFullYear()-1970)}n.d(t,"a",(function(){return c}))},7156:function(e,t,n){var c=n("1626"),a=n("861d"),o=n("d2bb");e.exports=function(e,t,n){var i,r;return o&&c(i=t.constructor)&&i!==n&&a(r=i.prototype)&&r!==n.prototype&&o(e,r),e}},"9fbc":function(e,t,n){"use strict";var c=n("7a23"),a=function(e){return Object(c["J"])("data-v-30baf8dd"),e=e(),Object(c["H"])(),e},o={class:"grid"},i={key:0},r={key:1},l={key:0},s=a((function(){return Object(c["m"])("br",null,null,-1)})),u={key:0},d={key:1,class:"no-data"},b={key:0},f=["id","value"],O={key:1},j=["onClick"],m={key:0},h=["onClick"];function p(e,t,n,a,p,v){var g,y,k;return Object(c["G"])(),Object(c["l"])(c["b"],null,[Object(c["m"])("table",o,[Object(c["m"])("thead",{class:Object(c["x"])(e.rowHeaderStyle?"".concat(e.rowHeaderStyle," header-grid"):"header-grid")},[Object(c["m"])("tr",null,[(null===(g=e.actions)||void 0===g?void 0:g.length)>0&&"delete"==e.actions[0].type&&e.dataSource.listaRecords.length>0?(Object(c["G"])(),Object(c["l"])("th",i,[Object(c["ab"])(Object(c["m"])("input",{type:"checkbox",id:"checkbox","onUpdate:modelValue":t[0]||(t[0]=function(t){return e.massiveCheck=t})},null,512),[[c["S"],e.massiveCheck]])])):Object(c["k"])("",!0),(Object(c["G"])(!0),Object(c["l"])(c["b"],null,Object(c["M"])(e.columns,(function(e){return Object(c["G"])(),Object(c["l"])("th",{key:e.field,style:Object(c["y"])({textAlign:e.align?e.align:"left"})},Object(c["Q"])(e.title),5)})),128)),(null===(y=e.actions)||void 0===y?void 0:y.length)>0?(Object(c["G"])(),Object(c["l"])("th",r,"Acciones")):Object(c["k"])("",!0)])],2),e.dataSource.listaRecords&&0===(null===(k=e.dataSource.listaRecords)||void 0===k?void 0:k.length)?(Object(c["G"])(),Object(c["l"])("div",l,[s,e.rowBodyStyle?(Object(c["G"])(),Object(c["l"])("p",d,"Sin registros")):(Object(c["G"])(),Object(c["l"])("h3",u,"No hay datos registrados"))])):Object(c["k"])("",!0),Object(c["m"])("tbody",{class:Object(c["x"])(e.rowBodyStyle?e.rowBodyStyle:"")},[(Object(c["G"])(!0),Object(c["l"])(c["b"],null,Object(c["M"])(e.rows,(function(n,a){var o,i;return Object(c["G"])(),Object(c["l"])("tr",{key:n},[(null===(o=e.actions)||void 0===o?void 0:o.length)>0&&"delete"==e.actions[0].type&&e.dataSource.listaRecords.length>0?(Object(c["G"])(),Object(c["l"])("td",b,[e.dataSource.listaRecords&&e.dataSource.listaRecords[a]?Object(c["ab"])((Object(c["G"])(),Object(c["l"])("input",{key:0,type:"checkbox",id:e.dataSource.listaRecords[a].id,value:e.dataSource.listaRecords[a].id,"onUpdate:modelValue":t[1]||(t[1]=function(t){return e.checkedEntities=t})},null,8,f)),[[c["S"],e.checkedEntities]]):Object(c["k"])("",!0)])):Object(c["k"])("",!0),(Object(c["G"])(!0),Object(c["l"])(c["b"],null,Object(c["M"])(e.columns,(function(t){return Object(c["G"])(),Object(c["l"])("td",{key:t.field},[Object(c["m"])("p",{style:Object(c["y"])({textAlign:t.align?t.align:"left"})},Object(c["Q"])(e.getValue(t.field,e.dataSource.listaRecords,n-1,t.type)),5)])})),128)),(null===(i=e.actions)||void 0===i?void 0:i.length)>0?(Object(c["G"])(),Object(c["l"])("td",O,[(Object(c["G"])(!0),Object(c["l"])(c["b"],null,Object(c["M"])(e.actions,(function(t){return Object(c["G"])(),Object(c["l"])("span",{key:t.type},[e.dataSource.listaRecords[a]?(Object(c["G"])(),Object(c["l"])("i",{key:0,class:Object(c["x"])(t.icon),style:{"margin-left":"18px"},onClick:function(n){return t.method(e.dataSource.listaRecords[a].id,e.dataSource.listaRecords[a].codigo,e.dataSource.listaRecords[a].entity)}},null,10,j)):Object(c["k"])("",!0)])})),128))])):Object(c["k"])("",!0)])})),128))],2)]),e.dataSource.numeroPaginas>1?(Object(c["G"])(),Object(c["l"])("div",m,[(Object(c["G"])(!0),Object(c["l"])(c["b"],null,Object(c["M"])(e.dataSource.numeroPaginas,(function(t){return Object(c["G"])(),Object(c["l"])("div",{key:t,class:"pageButton",onClick:function(n){return e.goPage(t)}},Object(c["Q"])(t),9,h)})),128))])):Object(c["k"])("",!0)],64)}n("a9e3"),n("d81d");var v=n("682b"),g=n("5c40"),y=n("d4ec"),k=function e(t,n,c){Object(y["a"])(this,e),this.listaRecords=t,this.numeroPaginas=n,this.totalRecords=c},S=Object(g["s"])({props:{columns:{type:Array,required:!0},dataSource:{type:k,required:!0},config:{type:null,required:!1},actions:{type:null,required:!1,default:[]},method:{type:Function,required:!1},rows:{type:Number,required:!1,default:5},pages:{type:Number,required:!0},rowHeaderStyle:{type:String,required:!1},rowBodyStyle:{type:String,required:!1}},emits:["selectedList","movePage"],data:function(){return{massiveCheck:!1,checkedEntities:[]}},watch:{massiveCheck:function(){this.massiveCheck?this.checkedEntities=this.dataSource.listaRecords.map((function(e){return e.id})):this.checkedEntities=[]},checkedEntities:function(){this.$emit("selectedList",this.checkedEntities)}},methods:{goPage:function(e){this.$emit("movePage",e)},getValue:function(e,t,n,c){if(t)return t[n]?"fechaNacimiento"===e?Object(v["a"])(t[n][e]):"date"===c?new Date(t[n][e]).toLocaleDateString():t[n][e]:""}}}),w=(n("38b4"),n("6b0d")),E=n.n(w);const x=E()(S,[["render",p],["__scopeId","data-v-30baf8dd"]]);t["a"]=x},a938:function(e,t,n){"use strict";n("b963")},a9e3:function(e,t,n){"use strict";var c=n("83ab"),a=n("da84"),o=n("e330"),i=n("94ca"),r=n("6eeb"),l=n("1a2d"),s=n("7156"),u=n("3a9b"),d=n("d9b5"),b=n("c04e"),f=n("d039"),O=n("241c").f,j=n("06cf").f,m=n("9bf2").f,h=n("408a"),p=n("58a8").trim,v="Number",g=a[v],y=g.prototype,k=a.TypeError,S=o("".slice),w=o("".charCodeAt),E=function(e){var t=b(e,"number");return"bigint"==typeof t?t:x(t)},x=function(e){var t,n,c,a,o,i,r,l,s=b(e,"number");if(d(s))throw k("Cannot convert a Symbol value to a number");if("string"==typeof s&&s.length>2)if(s=p(s),t=w(s,0),43===t||45===t){if(n=w(s,2),88===n||120===n)return NaN}else if(48===t){switch(w(s,1)){case 66:case 98:c=2,a=49;break;case 79:case 111:c=8,a=55;break;default:return+s}for(o=S(s,2),i=o.length,r=0;r<i;r++)if(l=w(o,r),l<48||l>a)return NaN;return parseInt(o,c)}return+s};if(i(v,!g(" 0o1")||!g("0b1")||g("+0x1"))){for(var C,G=function(e){var t=arguments.length<1?0:g(E(e)),n=this;return u(y,n)&&f((function(){h(n)}))?s(Object(t),n,G):t},R=c?O(g):"MAX_VALUE,MIN_VALUE,NaN,NEGATIVE_INFINITY,POSITIVE_INFINITY,EPSILON,MAX_SAFE_INTEGER,MIN_SAFE_INTEGER,isFinite,isInteger,isNaN,isSafeInteger,parseFloat,parseInt,fromString,range".split(","),N=0;R.length>N;N++)l(g,C=R[N])&&!l(G,C)&&m(G,C,j(g,C));G.prototype=y,y.constructor=G,r(a,v,G)}},aa14:function(e,t,n){"use strict";n("5ef3")},b7ff:function(e,t,n){"use strict";var c=n("7a23"),a=function(e){return Object(c["J"])("data-v-ea440b04"),e=e(),Object(c["H"])(),e},o={key:0,class:"modal"},i=a((function(){return Object(c["m"])("i",{class:"far fa-times-circle fa-2x"},null,-1)})),r={class:"flex-button"};function l(e,t,n,a,l,s){var u=Object(c["O"])("backdrop");return Object(c["G"])(),Object(c["l"])(c["b"],null,[Object(c["p"])(u,{show:e.show,onClose:e.tryClose,closable:!1},null,8,["show","onClose"]),e.show?(Object(c["G"])(),Object(c["l"])("div",o,[i,Object(c["m"])("p",null,Object(c["Q"])(e.title),1),Object(c["m"])("div",r,[Object(c["m"])("button",{onClick:t[0]||(t[0]=function(t){return e.confirm()}),class:"action-button"},"Aceptar"),Object(c["m"])("button",{style:{background:"var(--danger)"},onClick:t[1]||(t[1]=function(t){return e.cancel()}),class:"action-button"}," Cancelar ")])])):Object(c["k"])("",!0)],64)}var s=n("5c40"),u=n("c2de"),d=Object(s["s"])({components:{Backdrop:u["a"]},props:{show:{type:Boolean,required:!0},title:{type:String,required:!1},fixed:{type:Boolean,required:!1,default:!1},error:{type:Boolean,required:!0},loading:{type:Boolean,required:!0},massiveDelete:{type:Boolean,required:!1}},emits:["confirmMassive","close","confirm","cancel"],methods:{tryClose:function(){this.$emit("close")},confirm:function(){this.massiveDelete?this.$emit("confirmMassive"):this.$emit("confirm")},cancel:function(){this.$emit("cancel")}}}),b=(n("aa14"),n("6b0d")),f=n.n(b);const O=f()(d,[["render",l],["__scopeId","data-v-ea440b04"]]);t["a"]=O},b963:function(e,t,n){},d81d:function(e,t,n){"use strict";var c=n("23e7"),a=n("b727").map,o=n("1dde"),i=o("map");c({target:"Array",proto:!0,forced:!i},{map:function(e){return a(this,e,arguments.length>1?arguments[1]:void 0)}})}}]);
//# sourceMappingURL=chunk-3787b40c.6fa8f3ed.js.map