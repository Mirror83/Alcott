import React from "react";
import ReactDOM from "react-dom/client";
import { ChakraProvider } from "@chakra-ui/react";
import {
  VStack,
  HStack,
  Text,
  Input,
  Link,
  Button,
  Box,
} from "@chakra-ui/react";

const Login = () => {
  return (
    <>
      <Box bg="black" w="100%" p={4} color="white">
        <HStack spacing={750}>
          <Text>Alcott hardware login</Text>
          <HStack spacing={24}>
            <Text>Employee</Text>
            <Text>Admin</Text>
          </HStack>
        </HStack>
      </Box>
      <br />
      <VStack>
        <Text>Enter username or email:</Text>
        <Input variant="filled" width={350} />
        <Text>Enter password:</Text>
        <Input variant="filled" width={350} />

        <Link>Forgot password</Link>
        <Button>Submit</Button>
      </VStack>
    </>
  );
};

export default Login;
