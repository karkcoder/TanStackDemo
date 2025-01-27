import {
  createRootRoute,
  createRoute,
  createRouter,
} from "@tanstack/react-router";
import InsuranceMemberDetails from "../features/insurance-members/MemberDetails";
import MemberLists from "../features/insurance-members/MemberLists";

// Create a root route
const rootRoute = createRootRoute();

//Create individual routes
const indexRoute = createRoute({
  getParentRoute: () => rootRoute,
  path: "/",
  component: MemberLists,
});

const usersRoute = createRoute({
  getParentRoute: () => rootRoute,
  path: "insurance-members",
});

const userDetailsRoute = createRoute({
  getParentRoute: () => usersRoute,
  path: "$memberId",
  component: InsuranceMemberDetails,
});

// Create the route tree
const routeTree = rootRoute.addChildren([
  indexRoute,
  usersRoute.addChildren([userDetailsRoute]),
]);

// Create the router
export const router = createRouter({ routeTree });

// Register the router for type safety
declare module "@tanstack/react-router" {
  interface Register {
    router: typeof router;
  }
}
