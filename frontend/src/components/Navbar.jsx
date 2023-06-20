import React from "react";
import { Box, Text, HStack, Link } from "@chakra-ui/react";

function Navbar() {
  return (
    <div>
      <Box bg="black" w="100%" p={4} color="white">
        <HStack spacing={850}>
          <Link>Alcott</Link>
          <HStack spacing={24}>
            <Link>Emloyee</Link>
            <Link>Sign-out</Link>
          </HStack>
        </HStack>
      </Box>
    </div>
  );
}

export default Navbar;
