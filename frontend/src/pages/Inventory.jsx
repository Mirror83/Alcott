import React from "react";
import ReactDOM from "react-dom/client";
import { ChakraProvider, HStack } from "@chakra-ui/react";
import Navbar from "../components/Navbar";
import { Input, Text, Box, VStack } from "@chakra-ui/react";

function Inventory() {
  return (
    <>
      <Box>
        <VStack>
          <HStack>
            <Text as="b">Search:</Text>
            <Input htmlSize={15} width="auto" />
          </HStack>
          <HStack>
            <Text as="b">Filter by category:</Text>
            <Input htmlSize={15} width="auto" />
          </HStack>
        </VStack>
      </Box>
    </>
  );
}

export default Inventory;
