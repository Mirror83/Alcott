import React from "react";
import { Box, Text, HStack } from "@chakra-ui/react";

function Navbar() {
  return (
    <div>
      <Box bg="black" w="100%" p={4} color="white">
        <HStack spacing={850}>
          <Text>Alcott</Text>
          <HStack spacing={24}>
            <Text>Emloyee</Text>
            <Text>Sign-out</Text>
          </HStack>
        </HStack>
      </Box>
    </div>
  );
}

export default Navbar;
