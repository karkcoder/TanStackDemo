import {
  createRootRoute,
  createRoute,
  createRouter,
} from "@tanstack/react-router";
//import UsersList from "../features/users/UsersList";
import InsuranceMemberDetails from "../features/insurance-members/MemberDetails";

// Create a root route
const rootRoute = createRootRoute();

// Create individual routes
// const indexRoute = createRoute({
//   getParentRoute: () => rootRoute,
//   path: "/",
//   component: UsersList,
// });

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
  //indexRoute,
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
