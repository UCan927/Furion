(window.webpackJsonp=window.webpackJsonp||[]).push([[5,17,25],{227:function(e,a,t){"use strict";var l=t(3),r=t(0),n=t.n(r),s=t(217),c=t(219),m=t(218),o=t(10),i=t(62),f=t.n(i);function g({to:e,href:a,label:t,prependBaseUrlToHref:r,...s}){const m=Object(o.a)(e),i=Object(o.a)(a,{forcePrependBaseUrl:!0});return n.a.createElement(c.a,Object(l.a)({className:"footer__link-item"},a?{target:"_blank",rel:"noopener noreferrer",href:r?i:a}:{to:m},s),t)}const u=({url:e,alt:a})=>n.a.createElement("img",{className:"footer__logo",alt:a,src:e,style:{background:"#fff",padding:"5px 10px"}});a.a=function(){const{footer:e}=Object(m.useThemeConfig)(),{copyright:a,links:t=[],logo:l={}}=e||{},r=Object(o.a)(l.src);return e?n.a.createElement("footer",{className:Object(s.a)("footer",{"footer--dark":"dark"===e.style})},n.a.createElement("div",{className:"container"},t&&t.length>0&&n.a.createElement("div",{className:"row footer__links"},t.map((e,a)=>n.a.createElement("div",{key:a,className:"col footer__col"},null!=e.title?n.a.createElement("h4",{className:"footer__title"},e.title):null,null!=e.items&&Array.isArray(e.items)&&e.items.length>0?n.a.createElement("ul",{className:"footer__items"},e.items.map((e,a)=>e.html?n.a.createElement("li",{key:a,className:"footer__item",dangerouslySetInnerHTML:{__html:e.html}}):n.a.createElement("li",{key:e.href||e.to,className:"footer__item"},n.a.createElement(g,e)))):null))),(l||a)&&n.a.createElement("div",{className:"footer__bottom text--center"},l&&l.src&&n.a.createElement("div",{className:"margin-bottom--sm"},l.href?n.a.createElement("a",{href:l.href,target:"_blank",rel:"noopener noreferrer",className:f.a.footerLogoLink},n.a.createElement(u,{alt:l.alt,url:r})):n.a.createElement(u,{alt:l.alt,url:r})),a?n.a.createElement("div",{className:"footer__copyright",dangerouslySetInnerHTML:{__html:a}}):null))):null}},232:function(e,a,t){"use strict";t.d(a,"a",(function(){return o}));var l=t(0),r=t.n(l),n=t(217),s=t(219),c=t(66),m=t.n(c);function o({sidebar:e}){return 0===e.items.length?null:r.a.createElement("div",{className:Object(n.a)(m.a.sidebar,"thin-scrollbar")},r.a.createElement("h3",{className:m.a.sidebarItemTitle},e.title),r.a.createElement("ul",{className:m.a.sidebarItemList},e.items.map(e=>r.a.createElement("li",{key:e.permalink,className:m.a.sidebarItem},r.a.createElement(s.a,{isNavLink:!0,to:e.permalink,className:m.a.sidebarItemLink,activeClassName:m.a.sidebarItemLinkActive},e.title)))))}},79:function(e,a,t){"use strict";t.r(a);var l=t(0),r=t.n(l),n=t(226),s=t(219),c=t(232),m=t(220),o=t(218);a.default=function(e){const{tags:a,sidebar:t}=e,l={};Object.keys(a).forEach(e=>{const a=function(e){return e[0].toUpperCase()}(e);l[a]=l[a]||[],l[a].push(e)});const i=Object.entries(l).sort(([e],[a])=>e===a?0:e>a?1:-1).map(([e,t])=>r.a.createElement("div",{key:e},r.a.createElement("h3",null,e),t.map(e=>r.a.createElement(s.a,{className:"padding-right--md",href:a[e].permalink,key:e},a[e].name," (",a[e].count,")")),r.a.createElement("hr",null))).filter(e=>null!=e);return r.a.createElement(n.a,{title:"Tags",description:"Blog Tags",wrapperClassName:o.ThemeClassNames.wrapper.blogPages,pageClassName:o.ThemeClassNames.page.blogTagsListPage,searchMetadatas:{tag:"blog_tags_list"}},r.a.createElement("div",{className:"container margin-vert--lg"},r.a.createElement("div",{className:"row"},r.a.createElement("div",{className:"col col--3"},r.a.createElement(c.a,{sidebar:t})),r.a.createElement("main",{className:"col col--7"},r.a.createElement("h1",null,r.a.createElement(m.a,{id:"theme.tags.tagsPageTitle",description:"The title of the tag list page"},"Tags")),r.a.createElement("div",{className:"margin-vert--lg"},i)))))}}}]);