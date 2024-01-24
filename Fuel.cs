#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>

typedef enum {
    TOKEN_INT,
    TOKEN_ADD,
    TOKEN_SUB,
    TOKEN_MUL,
    TOKEN_DIV,
    TOKEN_LPAREN,
    TOKEN_RPAREN,
    TOKEN_EOF
} TokenType;

typedef struct {
    TokenType type;
    int value;
} Token;

void error(const char *message);
Token getNextToken();
int parseExpression();
int parseTerm();
int parseFactor();

Token currentToken;

int main() {
    currentToken = getNextToken();

    while (currentToken.type != TOKEN_EOF) {
        int result = parseExpression();
        printf("Result: %d\n");

        while (getchar() != '\n');

        currentToken = getNextToken();
    }

    return 0;
}

void error(const char *message) {
    fprintf(stderr, "Error: %s\n", message);
    exit(EXIT_FAILURE);
}

Token getNextToken() {
    Token token;
    int c = getchar();

    while (isspace(c)) {
        c = getchar();
    }

    if (c == EOF) {
        token.type = TOKEN_EOF;
    } else if (isdigit(c)) {
        ungetc(c, stdin);
        scanf("%d", &token.value);
        token.type = TOKEN_INT;
    } else {
        switch (c) {
            case '+':
                token.type = TOKEN_ADD;
                break;
            case '-':
                token.type = TOKEN_SUB;
                break;
            case '*':
                token.type = TOKEN_MUL;
                break;
            case '/':
                token.type = TOKEN_DIV;
                break;
            case '(':
                token.type = TOKEN_LPAREN;
                break;
            case ')':
                token.type = TOKEN_RPAREN;
                break;
            default:
                error("Invalid character");
        }
    }

    return token;
}

int parseExpression() {
    int result = parseTerm();

    while (currentToken.type == TOKEN_ADD || currentToken.type == TOKEN_SUB) {
        Token op = currentToken;
        currentToken = getNextToken();

        int term = parseTerm();

        if (op.type == TOKEN_ADD) {
            result += term;
        } else {
            result -= term;
        }
    }

    return result;
}

int parseTerm() {
    int result = parseFactor();

    while (currentToken.type == TOKEN_MUL || currentToken.type == TOKEN_DIV) {
        Token op = currentToken;
        currentToken = getNextToken();

        int factor = parseFactor();

        if (op.type == TOKEN_MUL) {
            result *= factor;
        } else {
            if (factor == 0) {
                error("Division by zero");
            }
            result /= factor;
        }
    }

    return result;
}

int parseFactor() {
    int result;

    if (currentToken.type == TOKEN_INT) {
        result = currentToken.value;
        currentToken = getNextToken();
    } else if (currentToken.type == TOKEN_LPAREN) {
        currentToken = getNextToken();
        result = parseExpression();

        if (currentToken.type != TOKEN_RPAREN) {
            error("Missing closing parenthesis");
        }

        currentToken = getNextToken();
    } else {
        error("Unexpected token");
    }

    return result;
}
#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>

typedef enum {
    TOKEN_INT,
    TOKEN_ADD,
    TOKEN_SUB,
    TOKEN_MUL,
    TOKEN_DIV,
    TOKEN_LPAREN,
    TOKEN_RPAREN,
    TOKEN_EOF
} TokenType;

typedef struct {
    TokenType type;
    int value;
} Token;

void error(const char *message);
Token getNextToken();
int parseExpression();
int parseTerm();
int parseFactor();

Token currentToken;

int main() {
    currentToken = getNextToken();

    while (currentToken.type != TOKEN_EOF) {
        int result = parseExpression();
        printf("Result: %d\n");

        while (getchar() != '\n');

        currentToken = getNextToken();
    }

    return 0;
}

void error(const char *message) {
    fprintf(stderr, "Error: %s\n", message);
    exit(EXIT_FAILURE);
}

Token getNextToken() {
    Token token;
    int c = getchar();

    while (isspace(c)) {
        c = getchar();
    }

    if (c == EOF) {
        token.type = TOKEN_EOF;
    } else if (isdigit(c)) {
        ungetc(c, stdin);
        scanf("%d", &token.value);
        token.type = TOKEN_INT;
    } else {
        switch (c) {
            case '+':
                token.type = TOKEN_ADD;
                break;
            case '-':
                token.type = TOKEN_SUB;
                break;
            case '*':
                token.type = TOKEN_MUL;
                break;
            case '/':
                token.type = TOKEN_DIV;
                break;
            case '(':
                token.type = TOKEN_LPAREN;
                break;
            case ')':
                token.type = TOKEN_RPAREN;
                break;
            default:
                error("Invalid character");
        }
    }

    return token;
}

int parseExpression() {
    int result = parseTerm();

    while (currentToken.type == TOKEN_ADD || currentToken.type == TOKEN_SUB) {
        Token op = currentToken;
        currentToken = getNextToken();

        int term = parseTerm();

        if (op.type == TOKEN_ADD) {
            result += term;
        } else {
            result -= term;
        }
    }

    return result;
}

int parseTerm() {
    int result = parseFactor();

    while (currentToken.type == TOKEN_MUL || currentToken.type == TOKEN_DIV) {
        Token op = currentToken;
        currentToken = getNextToken();

        int factor = parseFactor();

        if (op.type == TOKEN_MUL) {
            result *= factor;
        } else {
            if (factor == 0) {
                error("Division by zero");
            }
            result /= factor;
        }
    }

    return result;
}

int parseFactor() {
    int result;

    if (currentToken.type == TOKEN_INT) {
        result = currentToken.value;
        currentToken = getNextToken();
    } else if (currentToken.type == TOKEN_LPAREN) {
        currentToken = getNextToken();
        result = parseExpression();

        if (currentToken.type != TOKEN_RPAREN) {
            error("Missing closing parenthesis");
        }

        currentToken = getNextToken();
    } else {
        error("Unexpected token");
    }

    return result;
}
