// Set Element UI Lang
ELEMENT.locale(ELEMENT.lang.en)

// Init Chat Package
Vue.component('apexchart', VueApexCharts)
Vue.use(VueLoading);
Vue.component('loading', VueLoading)
// Top Component for Qtour, Sales, Volume
// props: ['by','valueby', 'qtour', 'sale', 'salevol'],
Vue.component('dash-heading', {
    template: `
        <el-row>
            <el-col :span="4">
                <div class="grid-content border-right">
                   
                    <div class="top-boad" align="center">
                        {{ qtour }}
                    </div>
                    <p class="boad-title">{{ name1 }}</p>
                </div>
            </el-col>
            <el-col :span="4">
                <div class="grid-content border-right">
                    <div class="top-boad" align="center">
					{{occu}}
                    </div>
                    <p class="boad-title">OCCUPIED APTT</p>
                </div>
            </el-col>
            <el-col :span="4">
                <div class="grid-content border-right">
                   
                    <div class="top-boad" align="center">
                        {{ ul }}
                    </div>
                    <p class="boad-title">{{ name2 }}</p>
                </div>
            </el-col>
            <el-col :span="4">
                <div class="grid-content border-right">
                    
                    <div class="top-boad" align="center">
                        {{ sale }}
                    </div>
                    <p class="boad-title">{{ name3 }}</p>
                </div>
            </el-col> 
            <el-col :span="4">
                <div class="grid-content">
                    
                    <div class="top-boad-vol" align="center">
                        {{ salevol | currency({
                            symbol: 'USD',
                            thousandsSeparator: ',',
                            fractionCount: 0,
                            fractionSeparator: '.',
                            symbolPosition: 'front',
                            symbolSpacing: true
                            })
                        }}
                    </div>
                    <p class="boad-title">{{ name4 }}</p>
                </div>
            </el-col>
            <el-col :span="4" v-if="by === 'DAY'">
                <div class="top-boad-vol" align="center">
                    {{ rsvd | currency({
                        symbol: 'USD',
                        thousandsSeparator: ',',
                        fractionCount: 0,
                        fractionSeparator: '.',
                        symbolPosition: 'front',
                        symbolSpacing: true
                        })
                    }}
                </div>
                <div class="grid-content">
                    <p class="boad-title">RVPD</p>
                </div>
            </el-col>
        </el-row>`,
    props: ['by','valueby', 'qtour', 'ul', 'sale', 'salevol','rsvd','occu'],
    data: function () {
        return {
            name1: "QUALIFIED TOURS",
            name2: "UNIQUE LEADS",
            name3: "SALES",
            name4: "SALES VOLUME",
            //RSVD:0
        }
    },
    methods:{
        RSVDs(){
            var current = moment().daysInMonth();
            var cc = moment().format("D");
            return current - cc;
        }
    }
})

Vue.component('dash-heading2', {
    template: `
        <el-row>
            <el-col :span="4">
                <div class="grid-content border-right">
                   
                    <div class="top-boad2" align="center">
                        {{ qtour }}
                    </div>
                    <p class="boad-title2">{{ name1 }}</p>
                </div>
            </el-col>
            <el-col :span="4">
                <div class="grid-content border-right">
                    <div class="top-boad2" align="center">
					{{ oabudget }}
                    </div>
                    <p class="boad-title2">OCCUPIED APTT BUDGET</p>
                </div>
            </el-col>
            <el-col :span="4">
                <div class="grid-content border-right">
                   
                    <div class="top-boad2" align="center">
                        {{ ul }}
                    </div>
                    <p class="boad-title2">{{ name2 }}</p>
                </div>
            </el-col>
            <el-col :span="4">
                <div class="grid-content border-right">
                    
                    <div class="top-boad2" align="center">
                        {{ sale }}
                    </div>
                    <p class="boad-title2">{{ name3 }}</p>
                </div>
            </el-col>
            <el-col :span="4">
                <div class="grid-content">
                    
                    <div class="top-boad-vol2" align="center">
                        {{ salevol | currency({
                            symbol: 'USD',
                            thousandsSeparator: ',',
                            fractionCount: 0,
                            fractionSeparator: '.',
                            symbolPosition: 'front',
                            symbolSpacing: true
                            })
                        }}
                    </div>
                    <p class="boad-title2">{{ name4 }}</p>
                </div>
            </el-col>
            <el-col :span="4">
            </el-col>
        </el-row>`,
    props: ['by','valueby', 'qtour', 'ul', 'sale', 'salevol', 'oabudget'],
    data: function () {
        return {
            name1: "QUALIFIED TOURS BUDGET",
            name2: "UNIQUE LEADS BUDGET",
            name3: "SALES BUDGET",
            name4: "SALES VOLUME BUDGET",
        }
    }
})

Vue.component('dash-heading-europe', {
    template: `
        <el-row>
            <el-col :span="3">
                <div class="grid-content border-right">
                    <div class="top-boad-eur_tit" align="left">
                       
                    </div>
                </div>
            </el-col>
            <el-col :span="4">
                <div class="grid-content border-right">
                   
                    <div class="top-boad-eur" align="center">
                        {{ qtour }}
                    </div>
                    <p class="boad-title">{{ name2 }}</p>
                </div>
            </el-col>
            <el-col :span="4">
                <div class="grid-content border-right">
                   
                    <div class="top-boad-eur" align="center">
                        {{ ul }}
                    </div>
                    <p class="boad-title">{{ name3 }}</p>
                </div>
            </el-col>
            <el-col :span="4">
                <div class="grid-content border-right">
                    
                    <div class="top-boad-eur" align="center">
                        {{ sale }}
                    </div>
                    <p class="boad-title">{{ name4 }}</p>
                </div>
            </el-col>
            <el-col :span="8">
                <div class="grid-content">
                    
                    <div class="top-boad-vol-eur" align="center">
                        {{ salevol | currency({
                            symbol: 'USD',
                            thousandsSeparator: ',',
                            fractionCount: 0,
                            fractionSeparator: '.',
                            symbolPosition: 'front',
                            symbolSpacing: true
                            })
                        }}
                    </div>
                    <p class="boad-title">{{ name5 }}</p>
                </div>
            </el-col>
        </el-row>`,
    props: ['by','valueby', 'qtour', 'ul', 'sale', 'salevol'],
    data: function () {
        return {
            name1: "PRE-COOLLING OFF",
            name2: "QUALIFIED TOURS",
            name3: "UNIQUE LEADS",
            name4: "SALES",
            name5: "SALES VOLUME",
        }
    }
})

Vue.component('dash-heading-europe-noncoll', {
    template: `
        <el-row>
            <el-col :span="4">
                <div class="grid-content border-right">
                   
                    <div class="top-boad-eur" align="center">
                        {{ qtour }}
                    </div>
                    <p class="boad-title">{{ name2 }}</p>
                </div>
            </el-col>
            <el-col :span="4">
                <div class="grid-content border-right">
                   
                    <div class="top-boad-eur" align="center">
					{{occu}}
                    </div>
                    <p class="boad-title">OCCUPIED APTT</p>
                </div>
            </el-col>
            <el-col :span="4">
                <div class="grid-content border-right">
                   
                    <div class="top-boad-eur" align="center">
                        {{ ul }}
                    </div>
                    <p class="boad-title">{{ name3 }}</p>
                </div>
            </el-col>
            <el-col :span="4">
                <div class="grid-content border-right">
                    
                    <div class="top-boad-eur" align="center">
                        {{ sale }}
                    </div>
                    <p class="boad-title">{{ name4 }}</p>
                </div>
            </el-col>
            <el-col :span="4">
                <div class="grid-content">
                    
                    <div class="top-boad-vol-eur" align="center">
                        {{ salevol | currency({
                            symbol: 'USD',
                            thousandsSeparator: ',',
                            fractionCount: 0,
                            fractionSeparator: '.',
                            symbolPosition: 'front',
                            symbolSpacing: true
                            })
                        }}
                    </div>
                    <p class="boad-title">{{ name5 }}</p>
                </div>
            </el-col>
            <el-col :span="4">
                <div class="grid-content">
                    
                    <div class="top-boad-vol-eur" align="center">
                        {{ rsvd | currency({
                            symbol: 'USD',
                            thousandsSeparator: ',',
                            fractionCount: 0,
                            fractionSeparator: '.',
                            symbolPosition: 'front',
                            symbolSpacing: true
                            })
                        }}
                    </div>
                    <p class="boad-title">RSVD</p>
                </div>
            </el-col>
        </el-row>`,
    props: ['by','valueby', 'qtour', 'ul', 'sale', 'salevol','rsvd','occu'],
    data: function () {
        return {
            name1: "POST-COOLLING OFF",
            name2: "QUALIFIED TOURS",
            name3: "UNIQUE LEADS",
            name4: "SALES",
            name5: "SALES VOLUME",
        }
    }
})

/**
 *  Component Graph
 *  props: ['act','qt']
 *  act { Object } -> Actual vs Budget
 *  qt { Object } -> VOLUME vs QTour
 *  
*/
Vue.component('dashgraph', {
    template: `
    <el-row class="margin-top">
        <el-col :span="12">
            <div class="grid-content">
                <div class="top-boadgraph">
                    <apexchart type="bar" width="90%" :options="act.options" :series="act.series" />
                </div>
            </div>
        </el-col>
        <el-col :span="12">
            <div class="grid-content">
                <div class="top-boadgraph">
                    <apexchart type="line" width="90%" :options="qt.chartOptions" :series="qt.series" />
                </div>
            </div>
        </el-col>
    </el-row>`,
    props: ['act','qt'],
})

if (VueCurrencyFilter) {
    Vue.use(VueCurrencyFilter, {
        symbol: "USD",
        thousandsSeparator: ",",
        fractionCount: 0,
        fractionSeparator: ".",
        symbolPosition: "front",
        symbolSpacing: false
    })
}


let app = new Vue({
    el: '#app',
    data: {
		radio1:"ALL",
        size: 120,
        px: "px",
        fullPage: false,
        isLoading: false,
        // Graph Value
        BUDGET:[],
		BUDGET2:[],
		ULBud:[],
        ACTUAL:[],
        Categories:[],
		SERIES: [],
        Labels: [],
        VOLUME:[],
		VOLUME2:[],
		VOLUME3:[],
		ActualGraph_Color:"#00E396",
		BudgetGraph_Color:"#1E90FF",
		BudgetGraph2_Color:"#FEB019",
		QtActualGraph_Color:"#2196F3",
		QtBudgetGraph_Color:"rgb(0, 227, 150)",
		ULActualGraph_Color:"rgb(254, 176, 25)",
		ULBudgetGraph_Color:"rgb(255, 69, 96)",	
		OAactualGraph_Color:"rgb(119, 93, 208)",
		OAbudgetGraph_Color:"rgba(165, 151, 139, 0.85)",
        QT:[],
        UL:[],
        isUL: false,
        //Init Top Dash
        QTour : 0,
		OccuAppt : 0,
        QUL : 0,
        Sales: 0,               
        Sales_nocool: 0,               
        SaleVol: 0,
        SaleVol_nocool: 0,
        RSVD:0,

        QTour_Bud : 0,
        QUL_Bud : 0,
        Sales_Bud: 0,                              
        SaleVol_Bud: 0,
		OA_Bud: 0,
        //TAP
        tabPosition: 'left',
        MainTap:"All",
        IndiaTap: "All",
        SeapTap: "All",
        EuropeTap: "All",
        INDIA_Data: [],
		EUROPE_Data:[],
        //Options
        loading: false,
        // PARAMS
        "Group": "",
        "Segment": "", 
        "by": "",
        "Date": "", 
        "typ": "",
        "venue": "", 
        "gvenue": "",
        //DateTime
        SelectTime:'DAY',
        value4: "",
        valueBy:'',
        valueByYear:'',
        pickerOptions1: {
            disabledDate(date) {
                return date > new Date()
            }
        },
		SEAPX: [],
		SubIndo: [],
        time: [
            {
                value: 'DAY',
                label: 'DAY'
            },
            {
                value: 'MONTH',
                label: 'MONTH'
            },
            {
                value: 'YEAR',
                label: 'YEAR'
            }
        ]
    },
    filters: {
        reverse: function (value) {
            return value.split('').reverse().join('')
        },
        Ucf: (value) => {
            let low = value.toLowerCase();
            low = low.split(" ");
            for (var i = 0, x = low.length; i < x; i++) {
                low[i] = low[i][0].toUpperCase() + low[i].substr(1);
            }
            return low.join(" ");
        }
    },
    methods: {
        setDate() {
            if (this.SelectTime == "DAY") {
                return 'date'
            } else if (this.SelectTime == "MONTH") {
                return 'month'
            } else if (this.SelectTime == "YEAR") {
                return 'year'     
            }
        },
        setDateFormat(){
            if (this.SelectTime == "DAY") {
                return 'dd-MMM-yyyy'
            } else if (this.SelectTime == "MONTH") {
                return 'MMM - yyyy'
            } else if (this.SelectTime == "YEAR") {
                return 'yyyy'     
            }
        },
        async dateByFuc(){
			//this.valueBy = moment(this.value4).format('YYYY-MM-DD'); 			
			if(this.SelectTime == "MONTH"){
				if((moment(this.value4,'YYYY-MMM-DD').month()) == (moment(new Date(),'YYYY-MMM-DD').month())){
					this.valueBy = moment(new Date()).format('YYYY-MM-DD')
					//this.valueBy = moment(this.value4).format('YYYY-MM-DD');
				}else{
					this.valueBy = moment(this.value4).endOf('month').format('YYYY-MM-DD');
				}				
			}
			else
			{
				this.valueBy = moment(this.value4).format('YYYY-MM-DD'); 
			}		
//console.log("VALUEBY: " +this.valueBy );
          /*  if (this.SelectTime == "YEAR"){
                //let valueBy = moment(this.value4).endOf('year').format('YYYY-MM-DD');
                //this.valueBy = moment(valueBy).endOf('month').format('YYYY-MM-DD');
                // this.valueBy = moment(this.value4).format('YYYY-MM-DD');
                this.valueBy = moment(this.value4).format('YYYY-MM-DD');
            } else if(this.SelectTime == "MONTH"){
                // this.valueBy = moment(this.value4).endOf('month').format('YYYY-MM-DD');
                this.valueBy = moment(this.value4).format('YYYY-MM-DD');
            } */					
    
            this.setValueGraph()
            this.setQT()
			
			
			
        },
        Ucf(value){
            let low = value.toLowerCase();
            low = low.split(" ");
            for (var i = 0, x = low.length; i < x; i++) {
                low[i] = low[i][0].toUpperCase() + low[i].substr(1);
            }
            return low.join(" ");
        },
        capitalize(s){
            return s != "" ? s.toUpperCase(): ""
        },
        /* Handle MainTab Click */
        async handleClick(tab, event){
            let val = this.Ucf(this.MainTap)
           
            this.SeapTap = this.EuropeTap = this.IndiaTap = "All"
			
            this.Segment = ""

            this.setQT()
            await this.setValueGraph()
        },
        async handleClickIndia(tab, event){
            let val = this.Ucf(this.IndiaTap)
            this.resetValueGraph()
            if (val != "All") {
                if (val == "Goa North") {
                    val = "North Goa"
                } else if (val == "Goa South") {
                    val = "South Goa"
                }
                this.Segment = val
            } else {
                this.Segment = ""
            }
            this.setQT()
            await this.setValueGraph()
        },
        async handleClickSeap(tab, event){
            let val = this.Ucf(this.SeapTap)	
			
            this.resetValueGraph()
            if (val != "All") {
                this.Segment = val
            } else {
                this.Segment = ""
            }
            this.setQT()
            await this.setValueGraph()
        },
        async handleClickEurope(tab, event){
            let val = this.Ucf(this.EuropeTap)
            this.resetValueGraph()
            if (val != "All") {
                this.Segment = val
            } else {
                this.Segment = ""
            }
            this.setQT()            
            await this.setValueGraph()
        },
        formatPrice(value) {
            let val = (value/1).toFixed(0).replace(',', '.')
            return val.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",")
        },
        RSVDs(b,a){
            var current = moment().daysInMonth();
            var cc = moment().format("D");
            bud = 0;
            acs = 0;            
           
            //b.forEach(bs => bud += bs);
            //a.forEach(bs => acs += bs);           
            var da = (b-a)/(current - cc)            
            return da;
        },
        abbrNum(number, decPlaces) {
            decPlaces = Math.pow(10,decPlaces);
            var abbrev = [ "k", "m", "b", "t" ];
            for (var i=abbrev.length-1; i>=0; i--) {
                var size = Math.pow(10,(i+1)*3);
                if(size <= number) {
                    number = Math.round(number*decPlaces/size)/decPlaces;
                    if((number == 1000) && (i < abbrev.length - 1)) {
                         number = 1;
                         i++;
                    }
                    number += abbrev[i];
                    break;
                }
            }
            return number;
        },
        async setQT(venue = ""){
            this.QTour = 0
            this.QUL = 0
            this.Sales = 0
            this.Sales_nocool = 0
            this.SaleVol = 0
            this.SaleVol_nocool = 0

            this.QTour_Bud = 0
            this.QUL_Bud = 0
            this.Sales_Bud = 0
            this.SaleVol_Bud = 0
			this.OA_Bud = 0

            this.RSVD = 0 
			
			let fillcolors = await axios.post('Dashboard.aspx/ApexChartGraphColor',{
								"Type": "graph_color",
								"Group": "actual"
							})
			
			this.ActualGraph_Color = fillcolors.data.d
			
			fillcolors = await axios.post('Dashboard.aspx/ApexChartGraphColor',{
								"Type": "graph_color",
								"Group": "QtActual"
							})
			this.QtActualGraph_Color = fillcolors.data.d	
			
			fillcolors = await axios.post('Dashboard.aspx/ApexChartGraphColor',{
								"Type": "graph_color",
								"Group": "QtBudget"
							})
			this.QtBudgetGraph_Color = fillcolors.data.d
			
			fillcolors = await axios.post('Dashboard.aspx/ApexChartGraphColor',{
								"Type": "graph_color",
								"Group": "ULActual"
							})
			this.ULActualGraph_Color = fillcolors.data.d
			
			fillcolors = await axios.post('Dashboard.aspx/ApexChartGraphColor',{
								"Type": "graph_color",
								"Group": "ULBudget"
							})
			this.ULBudgetGraph_Color = fillcolors.data.d
			
			fillcolors = await axios.post('Dashboard.aspx/ApexChartGraphColor',{
								"Type": "graph_color",
								"Group": "OAactual"
							})
			this.OAactualGraph_Color = fillcolors.data.d
			
			fillcolors = await axios.post('Dashboard.aspx/ApexChartGraphColor',{
								"Type": "graph_color",
								"Group": "OAbudget"
							})
			this.OAbudgetGraph_Color = fillcolors.data.d
			
			fillcolors = await axios.post('Dashboard.aspx/ApexChartGraphColor',{
								"Type": "graph_color",
								"Group": "budget"
							})
			this.BudgetGraph_Color = fillcolors.data.d	

			fillcolors = await axios.post('Dashboard.aspx/ApexChartGraphColor',{
								"Type": "graph_color",
								"Group": "budget2"
							})
			this.BudgetGraph2_Color = fillcolors.data.d	

            let Group = this.capitalize(this.MainTap)

            // console.log({
                // "Group": this.capitalize(Group),
                // "Segment": this.Segment, 
                // "by": this.SelectTime,
                // "Date": this.valueBy, 
                // "typ": "",
                // "venue": venue
            // })
            
			
			if(this.SeapTap == "Indonesia"){
				venue = this.radio1;
			}
						
            let dataQT = await axios.post('Dashboard.aspx/getValTop',{
                "Group": this.capitalize(Group),
                "Segment": this.Segment, 
                "by": this.SelectTime,
                "Date": this.valueBy, 
                "typ": "",
                "venue": venue
            })

            let jsn = JSON.parse(dataQT.data.d)				
            
            this.QTour = jsn.qt	
				
            this.QUL = jsn.ul
			this.OccuAppt = jsn.occuaptt
            
            this.Sales = jsn.sales
            this.Sales_nocool = jsn.sales_noncool

            this.SaleVol = jsn.vol
            this.SaleVol_nocool = jsn.vol_noncool

            let dataQTBud = await axios.post('Dashboard.aspx/getValTopBud',{
                "Group": this.capitalize(Group),
                "Segment": this.Segment, 
                "by": this.SelectTime,
                "Date": this.valueBy, 
                "typ": "",
                "venue": venue
            })

            let jsn_bud = JSON.parse(dataQTBud.data.d)
            
            this.QTour_Bud = jsn_bud.qt
            this.QUL_Bud = jsn_bud.ul
            this.Sales_Bud = jsn_bud.sales
            this.SaleVol_Bud = jsn_bud.vol
			this.OA_Bud = jsn_bud.oabudget			
            //this.RSVD = this.RSVDs(this.SaleVol_Bud,this.SaleVol)
        },
        resetValueGraph(){
            this.BUDGET = []
			this.BUDGET2 = []
            this.ACTUAL = []
            this.Categories = []
			this.ULBud = []

            this.Labels = []
            this.QT = []
            this.UL = []
            this.VOLUME = []
			this.VOLUME2 = []
			this.VOLUME3 = []
            this.RSVD = 0
        },
        async setValueGraph(){
            vm = this
            this.isLoading = true
            this.isUL = false
            this.resetValueGraph()
            this.BUDGET = [0,0,0]
			this.BUDGET2 = [0,0,0]
            this.ACTUAL = [0,0,0]
            this.QT = [0,0,0]              
            this.UL = [0,0,0] 
            this.VOLUME = [0,0,0]    
			this.VOLUME2 = [0,0,0]	
			this.VOLUME3 = [0,0,0]

            let dataQT = await axios.post('Dashboard.aspx/getAcBud',{
                    "Group": this.capitalize(this.MainTap),
                    "Segment": this.Segment, 
                    "by": this.SelectTime,
                    "Date": this.valueBy, 
                    "typ": "",
                    "venue": "", 
                    "gvenue": ""
                })
                
            let das = JSON.parse(dataQT.data.d)
			// console.log("main tap")
			            

            let lab = []
            let act = []
            let bud = []
			let bud2 = []
            let budQLUL = []
			let OAinhouse = []
			let OAactual = []
            let qt = []
            let ul = []
			let qulbudval = []

            if (this.MainTap == "Seap") { 
                this.Categories = this.SEAP
                this.Labels = this.SEAP
				this.isUL = true
                das.forEach(dd => {
                
                    //if (dd.name == 'Inhouse' || dd.name == 'Chang Mai' || dd.name == 'Phuket' || dd.name == 'Koh Samui'){
					if (dd.name == 'Inhouse' || dd.name == 'Chang Mai' || dd.name == 'Phuket'){	
                        //this.isUL = true
                        ul.push(dd.ul)
                        qt.push(0)
						budQLUL.push(0)
						OAactual.push(dd.oaactual)
						OAinhouse.push(dd.qtval)
						//if(this.SeapTap.toLowerCase() != 'indonesia'){							
							//OAinhouse.push(0)
							//OAactual.push(0)
						//}else{
							//budQLUL.push(dd.qtval)
							//OAinhouse.push(dd.qtval)
							
						//}
                    } 					
					else {

                        if (dd.name == 'Indonesia' || dd.name == 'Thailand' || dd.name == 'Vietnam' || dd.name == 'Chang Mai' || dd.name == 'Phuket'){
                            ul.push(dd.ul)
							OAactual.push(dd.oaactual)
							if(dd.name == 'Indonesia' || dd.name == 'Thailand' || dd.name == 'Vietnam'){
								OAinhouse.push(dd.oabudget)
							}else{
								OAinhouse.push(dd.qtval)
							}	
                        }else{
                            ul.push(0)
							OAactual.push(0)
							OAinhouse.push(0)
                        }
                        						
                        budQLUL.push(dd.qtval)
						
						
						qt.push(dd.qt)
                    }
					
                    bud.push(dd.budget)
					bud2.push(dd.budget2)
                    lab.push(dd.name)
                    act.push(dd.actual)
					this.RSVD = dd.rsvd
                                    
                })								
                
				
                this.VOLUME = budQLUL
				this.VOLUME2 = OAinhouse
				this.VOLUME3 = OAactual
				
                this.QT = qt
                this.UL = ul								

                this.BUDGET = bud
				this.BUDGET2 = bud2
                this.ACTUAL = act
                this.Categories = lab
                this.Labels = lab
                
            } else if (this.MainTap == "India"){
                this.Categories = this.INDIA
                this.Labels = this.INDIA
				//this.isUL = true
                
                das.forEach(dd => {
                    
                    qt.push(dd.qt)
                    if (dd.ul > 0 && this.IndiaTap != "All") {
                        this.isUL = true
                    }

                    budQLUL.push(dd.qtval)
                    ul.push(dd.ul)

                    bud.push(dd.budget)
					bud2.push(dd.budget2)
                    lab.push(this.Ucf(dd.name))
                    act.push(dd.actual)
					OAinhouse.push(dd.oabudget)
					OAactual.push(dd.oaactual)
					
					this.RSVD = dd.rsvd
                                    
                })

                this.VOLUME = budQLUL
                this.QT = qt
                this.UL = ul

                this.BUDGET = bud
				this.BUDGET2 = bud2
                this.ACTUAL = act
                this.Categories = lab
                this.Labels = lab
				this.VOLUME2 = OAinhouse
				this.VOLUME3 = OAactual
				
                
            } else if (this.MainTap == "Europe"){
                this.Categories = this.EUROPE
                this.Labels = this.EUROPE
                this.isUL = true
                das.forEach(dd => {
                    
					if (dd.name.toLowerCase() != 'coldline' || dd.name.toLowerCase() != 'flybuy'){
						budQLUL.push(0)
						OAactual.push(dd.oaactual)
						OAinhouse.push(dd.oabudget)
					}else if (dd.name.toLowerCase() == 'coldline' || dd.name.toLowerCase() == 'flybuy'){
						budQLUL.push(dd.qtval)
						OAactual.push(0)
						OAinhouse.push(0)
					}	
						
					
                    qt.push(dd.qt)
                    // if (dd.ul > 0 && this.EuropeTap != "All") {
                    //     this.isUL = true
                    // }

                    this.RSVD = dd.rsvd
                    ul.push(dd.ul)

                    bud.push(dd.budget)
					bud2.push(dd.budget2)
                    lab.push(this.Ucf(dd.name))
                    act.push(dd.actual)                                    
                })

                this.VOLUME = budQLUL
				this.VOLUME2 = OAinhouse
				this.VOLUME3 = OAactual
                this.QT = qt
                this.UL = ul

                this.BUDGET = bud
				this.BUDGET2 = bud2
                this.ACTUAL = act
                this.Categories = lab
                this.Labels = lab
                
            } else if (this.MainTap == "All"){
                this.Categories = this.ALL
                this.Labels = this.ALL
                this.isUL = true
                das.forEach(dd => {
                    
                    qt.push(dd.qt)
                    // if (dd.ul > 0 && this.EuropeTap != "All") {
                    //     this.isUL = true
                    // }

                    budQLUL.push(dd.qtval)
                    ul.push(dd.ul)

                    bud.push(dd.budget)
					bud2.push(dd.budget2)
                    lab.push(this.Ucf(dd.name))
                    act.push(dd.actual)
					qulbudval.push(dd.qulbudval)	
                })

                this.VOLUME = budQLUL
                this.QT = qt
                this.UL = ul

                this.BUDGET = bud
				this.BUDGET2 = bud2
                this.ACTUAL = act
                this.Categories = lab
                this.Labels = lab
				this.ULBud = qulbudval
                
            }
			
			this.RSVD = this.RSVDs(this.RSVD,0)
			
			if (this.SelectTime != "DAY") {
				this.SERIES = [
						{
							name: 'ACTUAL',
							data: this.ACTUAL
						},
						{
							name: 'BUDGET('+ ((this.SelectTime == "MONTH") ? "MTD" : "YTD") +')',
							data: this.BUDGET
						},
						{
							name: 'BUDGET',
							data: this.BUDGET2
						}
					]
			}else{
				this.SERIES = [
						{
							name: 'ACTUAL',
							data: this.ACTUAL
						},
						{
							name: 'BUDGET',
							data: this.BUDGET
						}
					]
			}		
            
            this.isLoading = false
            
        }
    },
    computed: {
        INDIA: function(){
            // let india = this.INDIA_Data
            // let newarr = []
			
            // newarr.push("Roadshow")
			// console.log("india test3");
				// console.log(india);
            // india.forEach(ns => {
                // let nss = ns.toLowerCase()
				// console.log("india oka test");
				// console.log(nss);
                // if (!nss.includes("roadshow")) {
                    // if (nss == "north goa") {
                        // newarr.push("Goa North")
                    // } else if (nss == "south goa") {
                        // newarr.push("Goa South")     
                    // } else {
                        // newarr.push(this.Ucf(ns))
                    // }
                // }
            // })					
            return this.INDIA_Data.sort((a,b) => (a.alias > b.alias) ? 1 : ((b.alias > a.alias) ? -1 : 0))
        },
        ALL: function(){
            //let seap = `<% Response.Write(getSeap()); %>`
            let seap =  'SEAP;EUROPE;INDIA;'
            let labs = seap.split(";")
            newLabs = labs.slice(0, -1)
            return newLabs
        },
        SEAP: function(){
            //let seap = `<% Response.Write(getSeap()); %>`
            let seap =  'Indonesia;Vietnam;Thailand;'
            let labs = seap.split(";")
            newLabs = labs.slice(0, -1)
			
            return newLabs.sort()
			
			
			
			// return [
            // {
                // country: 'Indonesia',
                // alias: 'Ind'
            // },
            // {
                // country: 'Vietnam',
                // alias: 'Viet'
            // },
            // {
                // country: 'Thailand',
                // alias: 'Thai'
            // }
        //]
			
        },
        EUROPE: function(){
            //let europe = `<% Response.Write(getEurope()); %>`
            //let europe =  'Ireland;France;Germany;Greece;Italy;'
            // let europe =  'France;Germany;Greece;Italy;'
            // let labs = europe.split(";")
            // newLabs = labs.slice(0, -1)
            // return newLabs.sort()
			return this.EUROPE_Data.sort((a,b) => (a.alias > b.alias) ? 1 : ((b.alias > a.alias) ? -1 : 0))
        },		
        AcVsBudGraph: function() {
            let vm = this			
						
            return {
                options: 
                {
                    stroke: {
                        width: [0, 4]
                    },
                    title: {
                        text: "ACTUAL vs BUDGET"
                    },
                    colors:[vm.ActualGraph_Color,vm.BudgetGraph_Color,vm.BudgetGraph2_Color],
                    fill: {
                        colors: [vm.ActualGraph_Color,vm.BudgetGraph_Color,vm.BudgetGraph2_Color]
                    },
                    plotOptions: {
                        bar: {
                            horizontal: false,
                            columnWidth: '55%',
                        },
                    },
                    dataLabels: {
                        enabled: false
                    },
                    stroke: {
                        show: true,
                        width: 2,
                        colors: ['transparent']
                    },
                    tooltip: {
                        y: {
                            formatter: function (val) {
                                return vm.formatPrice(val)+" $USD"
                            }
                        }
                    },
                    xaxis: {
                        categories: this.Categories,
                    },
                    yaxis: {
                        title: {
                            text: '$USD'
                        },
                        labels: {
                            formatter: function (value) {
                                return vm.abbrNum(value,0)
                            }
                        }
                    },
                },
                series: this.SERIES
            }
        },
        QtVsVolGraph: function() {
            let vm = this
            let nas = this.MainTap == "India" ? "UL Budget":"QT Budget"
            let text = this.isUL == true ? 'QT & UL': 'QT & UL'
            let yaxisSER = this.isUL == true ? 'QT & UL': 'QT & UL'			
            let series = this.isUL == true ? (this.MainTap == "India" ? [
                {
                    name: 'QT Actual',
                    type: 'column',
                    data: this.QT
                },
                {
                    name: nas,
                    type: 'column',
                    data: this.VOLUME
                },
                {
                    name: 'UL Actual',
                    type: 'column',
                    data: this.UL
                },
				{
                    name: 'OA Actual',
                    type: 'column',
                    data: this.VOLUME3
                },
				{
                    name: 'OA Budget',
                    type: 'column',
                    data: this.VOLUME2
                }	
            ] : [
                {
                    name: 'QT Actual',
                    type: 'column',
                    data: this.QT
                },
                {
                    name: nas,
                    type: 'column',
                    data: this.VOLUME
                },
                {
                    name: 'UL Actual',
                    type: 'column',
                    data: this.UL
                }
				,
                {
                    name: 'UL Budget',
                    type: 'column',
                    data: this.ULBud
                },
				{
                    name: 'OA Actual',
                    type: 'column',
                    data: this.VOLUME3
                },
				{
                    name: 'OA Budget',
                    type: 'column',
                    data: this.VOLUME2
                }
            ]) : [
                {
                    name: 'QT Actual',
                    type: 'column',
                    data: this.QT
                },			
                {
                    name: 'UL Actual',
                    type: 'column',
                    data: this.UL
                }				
            ]

            let yaxis = this.isUL == false ? [
                {
                    title: {
                        text: yaxisSER,
                    },
                    tooltip: {
                        enabled: false
                    }
                }
            ] : [
                {
                    title: {
                        text: yaxisSER,
                    },
                    tooltip: {
                        enabled: false
                    }
                }
            ]

            return {
                series: series,
                chartOptions: {
                    tooltip: {
                        y: {
                            formatter: function(value, { series, seriesIndex, dataPointIndex, w }) {
                                if (vm.isUL ==  false) {
                                    return value                                   
                                } else {
                                    if ( value > 0)  return value
                                }
                            }
                        }
                    },                    
                    stroke: {
                        show: false,						
                    },                 
                    title: {
                        text: text
                    },
					colors:[vm.QtActualGraph_Color,vm.QtBudgetGraph_Color,vm.ULActualGraph_Color,vm.ULBudgetGraph_Color,vm.OAactualGraph_Color,vm.OAbudgetGraph_Color],
                    fill: {
                        colors: [vm.QtActualGraph_Color,vm.QtBudgetGraph_Color,vm.ULActualGraph_Color,vm.ULBudgetGraph_Color,vm.OAactualGraph_Color,vm.OAbudgetGraph_Color]
                    },
                    labels: this.Labels,
                    yaxis: yaxis
                }
            }
        }
    },
    watch: {
        AcVsBudGraph: function (val) {
            return this.AcVsBudGraph
        },
        QtVsVolGraph:function (val) {
            return this.QtVsVolGraph
        }
    },
    created: async function(){

        let date =  new Date()
        this.value4 = date
        this.valueBy = moment(this.value4).format("YYYY-MM-DD")

        let dataIndia = await axios.post('Dashboard.aspx/getIndia',{})
        this.INDIA_Data = (new Function("return [" + dataIndia.data.d+ "];")())
		
		
		let dataSEAP = await axios.post('Dashboard.aspx/getDashSet',{
                "Type": "region",
                "Group": "seap"
            })
		let dataEUROPE = await axios.post('Dashboard.aspx/getDashSet',{
                "Type": "region",
                "Group": "EUROPE"
            })	
		let dataIndoResorts = await axios.post('Dashboard.aspx/getDashSet',{
                "Type": "seap",
                "Group": "Indonesia"
            })	
		this.EUROPE_Data = (new Function("return [" + dataEUROPE.data.d+ "];")())
		this.SubIndo = 	(new Function("return [" + dataIndoResorts.data.d+ "];")())
		var SEAPXStringArray = (new Function("return [" + dataSEAP.data.d+ "];")())	
		this.SEAPX = SEAPXStringArray				
						
        //this.setValueGraph()
    },
    mounted() {
        this.setQT()
        this.setValueGraph()
        this.$nextTick(function () {
            window.setInterval(() => {
                this.setQT();
                this.setValueGraph();
            },900000);
        })
    }
})



