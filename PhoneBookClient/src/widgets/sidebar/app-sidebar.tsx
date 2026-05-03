import {
    Sidebar,
    SidebarContent,
    SidebarFooter,
    SidebarGroup, SidebarGroupContent, SidebarGroupLabel,
    SidebarHeader, SidebarMenuButton, SidebarMenuItem, SidebarMenuSub,
} from "@/shared/ui/sidebar"
import {Collapsible, CollapsibleContent, CollapsibleTrigger} from "@/shared/ui/collapsible.tsx";
import {ChevronRight} from "lucide-react";
import {Link} from "react-router";

const navMenu = [
    {
        title: "Users",
        items: [
            {
                title: "Get All",
                url: "/users"
            },
            {
                title: "Create New",
                url: "/users/create"
            }
        ]
    },
    {
        title: "Phones",
        items: [
            {
                title: "Get All",
                url: "/phones"
            },
            {
                title: "Create New",
                url: "/phones/create"
            }
        ]
    },
];

export function AppSidebar() {
    return (
        <Sidebar>
            <SidebarHeader>
                <h1 className="text-4xl mt-4 ml-3">PhoneBook</h1>
            </SidebarHeader>
            <SidebarContent>
                <SidebarGroup>
                    {navMenu.map((item) => (
                        <Collapsible key={item.title} title={item.title} defaultOpen className="group/collapsible">
                            <SidebarGroup>
                                <SidebarGroupLabel asChild
                                                   className="group/label text-sm text-sidebar-foreground hover:bg-sidebar-accent hover:text-sidebar-accent-foreground">
                                    <CollapsibleTrigger>
                                        {item.title}{" "}
                                        <ChevronRight
                                            className="ml-auto transition-transform group-data-[state=open]/collapsible:rotate-90"/>
                                    </CollapsibleTrigger>
                                </SidebarGroupLabel>
                                <CollapsibleContent>
                                    <SidebarGroupContent>
                                        <SidebarMenuSub>
                                            {item.items.map((item) => (
                                                <SidebarMenuItem key={item.title}>
                                                    <SidebarMenuButton asChild>
                                                        <Link to={item.url} prefetch="intent">{item.title}</Link>
                                                    </SidebarMenuButton>
                                                </SidebarMenuItem>
                                            ))}
                                        </SidebarMenuSub>
                                    </SidebarGroupContent>
                                </CollapsibleContent>
                            </SidebarGroup>
                        </Collapsible>
                    ))}
                </SidebarGroup>
            </SidebarContent>
            <SidebarFooter/>
        </Sidebar>
    )
}