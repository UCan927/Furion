"use strict";(self.webpackChunkfurion=self.webpackChunkfurion||[]).push([[7920],{8824:function(e,t,n){n.d(t,{c:function(){return o}});var r=n(7294),a=n(2263),l=["zero","one","two","few","many","other"];function u(e){return l.filter((function(t){return e.includes(t)}))}var c={locale:"en",pluralForms:u(["one","other"]),select:function(e){return 1===e?"one":"other"}};function s(){var e=(0,a.Z)().i18n.currentLocale;return(0,r.useMemo)((function(){try{return t=e,n=new Intl.PluralRules(t),{locale:t,pluralForms:u(n.resolvedOptions().pluralCategories),select:function(e){return n.select(e)}}}catch(r){return console.error('Failed to use Intl.PluralRules for locale "'+e+'".\nDocusaurus will fallback to the default (English) implementation.\nError: '+r.message+"\n"),c}var t,n}),[e])}function o(){var e=s();return{selectMessage:function(t,n){return function(e,t,n){var r=e.split("|");if(1===r.length)return r[0];r.length>n.pluralForms.length&&console.error("For locale="+n.locale+", a maximum of "+n.pluralForms.length+" plural forms are expected ("+n.pluralForms.join(",")+"), but the message contains "+r.length+": "+e);var a=n.select(t),l=n.pluralForms.indexOf(a);return r[Math.min(l,r.length-1)]}(n,t,e)}}}},1473:function(e,t,n){n.r(t),n.d(t,{default:function(){return q}});var r=n(1017),a=n(4035),l=n(7294),u=n(2263),c=n(5822),s=n(5742),o=n(9960),i=n(5999),m=n(373),h=n(4700),f=n(8824),p=n(143),d=n(6775),g=n(412);var v=function(){var e=(0,d.k6)(),t=(0,d.TH)(),n=(0,u.Z)().siteConfig.baseUrl;return{searchValue:g.Z.canUseDOM&&new URLSearchParams(t.search).get("q")||"",updateSearchPath:function(n){var r=new URLSearchParams(t.search);n?r.set("q",n):r.delete("q"),e.replace({search:r.toString()})},generateSearchPageLink:function(e){return n+"search?q="+encodeURIComponent(e)}}},E=n(22),y=n(8202),S=n(2539),w=n(726),I=n(2775),b=n(311),F=n(3926),P=n(1029),R="searchQueryInput_CFBF",k="searchResultItem_U687",Z="searchResultItemPath_uIbk",C="searchResultItemSummary_oZHr";function x(){var e=(0,u.Z)().siteConfig.baseUrl,t=(0,p.gA)(),n=e;try{var c,o=(0,m.J)(null!=(c=null==t?void 0:t.pluginId)?c:P.gQ).preferredVersion;o&&!o.isLast&&(n=o.path+"/")}catch(N){if(P.l9&&!(N instanceof h.i6))throw N}var d=(0,f.c)().selectMessage,g=v(),S=g.searchValue,w=g.updateSearchPath,I=(0,l.useState)(S),F=I[0],k=I[1],Z=(0,l.useState)(),C=Z[0],x=Z[1],q=(0,l.useState)(),T=q[0],M=q[1],U=(0,l.useMemo)((function(){return F?(0,i.I)({id:"theme.SearchPage.existingResultsTitle",message:'Search results for "{query}"',description:"The search page title for non-empty query"},{query:F}):(0,i.I)({id:"theme.SearchPage.emptyResultsTitle",message:"Search the documentation",description:"The search page title for empty query"})}),[F]);(0,l.useEffect)((function(){w(F),C&&(F?C(F,(function(e){M(e)})):M(void 0))}),[F,C]);var L=(0,l.useCallback)((function(e){k(e.target.value)}),[]);return(0,l.useEffect)((function(){S&&S!==F&&k(S)}),[S]),(0,l.useEffect)((function(){function e(){return(e=(0,a.Z)((0,r.Z)().mark((function e(){var t,a,l;return(0,r.Z)().wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return e.next=2,(0,E.w)(n);case 2:t=e.sent,a=t.wrappedIndexes,l=t.zhDictionary,x((function(){return(0,y.v)(a,l,100)}));case 6:case"end":return e.stop()}}),e)})))).apply(this,arguments)}!function(){e.apply(this,arguments)}()}),[n]),l.createElement(l.Fragment,null,l.createElement(s.Z,null,l.createElement("meta",{property:"robots",content:"noindex, follow"}),l.createElement("title",null,U)),l.createElement("div",{className:"container margin-vert--lg"},l.createElement("h1",null,U),l.createElement("input",{type:"search",name:"q",className:R,"aria-label":"Search",onChange:L,value:F,autoComplete:"off",autoFocus:!0}),!C&&F&&l.createElement("div",null,l.createElement(b.Z,null)),T&&(T.length>0?l.createElement("p",null,d(T.length,(0,i.I)({id:"theme.SearchPage.documentsFound.plurals",message:"1 document found|{count} documents found",description:'Pluralized label for "{count} documents found". Use as much plural forms (separated by "|") as your language support (see https://www.unicode.org/cldr/cldr-aux/charts/34/supplemental/language_plural_rules.html)'},{count:T.length}))):l.createElement("p",null,(0,i.I)({id:"theme.SearchPage.noResultsText",message:"No documents were found",description:"The paragraph for empty search result"}))),l.createElement("section",null,T&&T.map((function(e){return l.createElement(_,{key:e.document.i,searchResult:e})})))))}function _(e){var t=e.searchResult,n=t.document,r=t.type,a=t.page,u=t.tokens,c=t.metadata,s=0===r,i=2===r,m=(s?n.b:a.b).slice(),h=i?n.s:n.t;return s||m.push(a.t),l.createElement("article",{className:k},l.createElement("h2",null,l.createElement(o.Z,{to:n.u+(n.h||""),dangerouslySetInnerHTML:{__html:i?(0,S.C)(h,u):(0,w.o)(h,(0,I.m)(c,"t"),u,100)}})),m.length>0&&l.createElement("p",{className:Z},(0,F.e)(m)),i&&l.createElement("p",{className:C,dangerouslySetInnerHTML:{__html:(0,w.o)(n.t,(0,I.m)(c,"t"),u,100)}}))}var q=function(){return l.createElement(c.Z,null,l.createElement(x,null))}}}]);