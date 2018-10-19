function test(param)
{
    try {
        var element = document.getElementById(param);
        element.style.background = "green";
        element.style.visibility = "visible";
        element.style.width = "350px";
    } catch (e) {
        alert(e.toString());
    }
}

function show(param) {
    try {
        var element = document.getElementById(param);
        element.style.visibility = "hidden";
    } catch (e) {
        alert(e.toString());
    }
}

function UnHide(eThis) {
    if (eThis.innerHTML.charCodeAt(0) === 9658) {
        eThis.innerHTML = "&#9660;";
        eThis.parentNode.parentNode.parentNode.className = "";
    } else {
        eThis.innerHTML = "&#9658;";
        eThis.parentNode.parentNode.parentNode.className = "cl";
    }
    return false;
}

function post() {
    try {
        var n1Old = $("#N1Old").val();
        var n1New = $("#N1New").val();
        var returnet;
        $.ajax({
            url: "http://10.177.234.151:8181/ServiceRest/SqlFaceAdd",
            type: "POST",
            contentType: "application/json",
            dataType: "json",
            data: '{"N1New":' + n1New + ',"N1Old":' + n1Old + '}',
            success: function (resultdata) {
                alert(JSON.stringify(resultdata).toString());
            },
            error: function (e) { alert(e.toString()); }
        });
    } catch (e) {
        alert(e.toString());
    }
}

//(function () {
//    'use strict';

//    angular.module('myMenuApp.controllers')
//        .controller('HomeCtrl',
//        [
//            '$rootScope',
//            '$log',
//            '$state',
//            '$timeout',
//            '$location',
//            'menu',
//            '$mdSidenav',
//            '$mdUtil',
//            function($rootScope, $log, $state, $timeout, $location, menu, $mdSidenav, $mdUtil) {

//                var vm = this;
//                var aboutMeArr = ['Family', 'Location', 'Lifestyle'];
//                var budgetArr = ['Housing', 'LivingExpenses', 'Healthcare', 'Travel'];
//                var incomeArr = ['SocialSecurity', 'Savings', 'Pension', 'PartTimeJob'];
//                var advancedArr = ['Assumptions', 'BudgetGraph', 'AccountBalanceGraph', 'IncomeBalanceGraph'];

//                function isOpen(section) {
//                    return menu.isSectionSelected(section);
//                };

//                function toggleOpen(section) {
//                    menu.toggleSelectSection(section);
//                };

//                //handler to open/close a SideNav; when animation finishes report completion in console
//                function buildToggler(navID) {
//                    return $mdUtil.debounce(function() {
//                            $mdSidenav(navID).toggle();
//                        },
//                        300);
//                };

//                //functions for menu-link and menu-toggle
//                vm.isOpen = isOpen;
//                vm.toggleOpen = toggleOpen;
//                vm.autoFocusContent = false;
//                vm.menu = menu;

//                vm.status = {
//                    isFirstOpen: true,
//                    isFirstDisabled: false
//                };

//                vm.toggleMenu = buildToggler('left');

//            }
//        ]);
//})();


    //@*<div layout="row">
    //    <section layout="column" layout-fill>
    //        <md-sidenav class="md-sidenav-left md-whiteframe-z1" md-component-id="left" md-is-locked-open="$mdMedia('gt-sm')">
    //            <md-toolbar class="md-toolbar-tools" md-scroll-shrink>
    //                <h3>My App Title</h3>
    //                <md-button aria-label="Close" class="md-icon-button" ng-click="vm.toggleMenu()" hide-gt-sm>
    //                    X
    //                </md-button>
    //            </md-toolbar>
    //            <md-content role="navigation">
    //                <ul class="side-menu">
    //                    <li ng-repeat="section in vm.menu.sections" class="parent-list-item"
    //                        ng-class="{'parentActive' : vm.isSectionSelected(section)}">
    //                        <h2 class="menu-heading" ng-if="section.type === 'heading'"
    //                            id="heading_{{ section.name | nospace }}">
    //                            {{section}}
    //                        </h2>
    //                        <menu-link section="section" ng-if="section.type === 'link'"></menu-link>
    //                        <menu-toggle section="section" ng-if="section.type === 'toggle'"></menu-toggle>
    //                    </li>
    //                </ul>
    //            </md-content>
    //        </md-sidenav>
    //        <md-toolbar hide-gt-sm>
    //            <md-button aria-label="Menu" class="md-icon-button" ng-click="vm.toggleMenu()">
    //                <svg style="width:24px;height:24px" viewBox="0 0 24 24">
    //                    <path fill="currentColor" d="M3,6H21V8H3V6M3,11H21V13H3V11M3,16H21V18H3V16Z" />
    //                </svg>
    //            </md-button>
    //        </md-toolbar>
    //        <md-content flex>
    //            <ui-view name="content"></ui-view>
    //        </md-content>
    //    </section>
    //</div>*@