describe("Registration page", function () {
  it("show registration page", function () {
    cy.server();
    cy.route({
      method: "GET",
      url: "/api/weeks/0",
      response: "fixture:week",
    });

    cy.visit("inschrijven");
    cy.get("[data-cy=registrationForm]").should("be.visible");
    cy.get("[data-cy=registrationButton]").should("be.disabled");
  });

  it("show next week", function () {
    cy.server();
    cy.route({
      method: "GET",
      url: "/api/weeks/0",
      response: "fixture:week",
    });
    cy.route({
      method: "GET",
      url: "/api/weeks/1",
      response: "fixture:week",
    });

    cy.visit("inschrijven");
    cy.get("[data-cy=registrationForm]").should("be.visible");
    cy.get("[data-cy=registrationButton]").should("be.disabled");
    cy.get("[data-cy=previousWeekButton]").should("be.disabled");
    cy.get("[data-cy=nextWeekButton]").should("be.enabled");
    cy.get("[data-cy=nextWeekButton]").click();
    cy.get("[data-cy=registrationForm]").should("be.visible");
    cy.get("[data-cy=registrationButton]").should("be.disabled");
  });

  it("create registration, succesfull", function () {
    cy.server();
    cy.route({
      method: "GET",
      url: "/api/weeks/0",
      response: "fixture:week",
    });
    cy.route({
      method: "POST",
      url: "/api/trainings/42/registrations/",
      status: 201,
      response: {
        timeStamp: new Date(),
        name: "Sterre De Maeyer",
      },
    }).as("post");

    cy.visit("inschrijven");
    cy.get("[data-cy=registrationButton]").should("be.disabled");
    cy.get("[data-cy=registrationTable]").find("tr").eq(1).click();
    cy.get("[data-cy=registrationNameField]").type("Sterre De Maeyer");
    cy.get("[data-cy=registrationButton]").click();
    cy.wait("@post").its("status").should("eq", 201);
    cy.url().should("include", "ingeschreven");
    cy.get("[data-cy=registrationButton]").should("not.exist");
    cy.get("[data-cy=returnToRegistrations]").click();
    cy.get("[data-cy=registrationButton]").should("be.disabled");

  });

  it("create registration, post unsuccesfull, show error", function () {
    cy.server();
    cy.route({
      method: "GET",
      url: "/api/weeks/0",
      response: "fixture:week",
    });
    cy.route({
      method: "POST",
      url: "/api/trainings/42/registrations/",
      status: 500,
      response: "ERROR",
    }).as("post");

    cy.visit("inschrijven");
    cy.get("[data-cy=registrationButton]").should("be.disabled");
    cy.get("[data-cy=registrationTable]").find("tr").eq(1).click();
    cy.get("[data-cy=registrationNameField]").type("Sterre De Maeyer");
    cy.get("[data-cy=registrationButton]").click();
    cy.get("[data-cy=error]").should("be.visible");
  });

  it("no trainings for week, show no trainings message", function () {
    cy.server();
    cy.route({
      method: "GET",
      url: "/api/weeks/0",
      response: "fixture:emptyWeek",
    });

    cy.visit("inschrijven");
    cy.get("[data-cy=message]").should("be.visible");
    cy.get("[data-cy=registrationForm]").should("not.exist");
  });

  it("on server error, show error page", function () {
    cy.server();
    cy.route({
      method: "GET",
      url: "/api/weeks/0",
      status: 500,
      response: "ERROR",
    });

    cy.visit("inschrijven");
    cy.get("[data-cy=error]").should("be.visible");
  });
});
